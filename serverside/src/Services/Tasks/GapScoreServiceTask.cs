using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cis.Models;
using Microsoft.EntityFrameworkCore;
using Cis.Enums;

namespace Cis.Services.Tasks
{
    public class GapScoreServiceTask
    {
        private readonly CisDBContext _dbContext;
        private double needForAboriginalServiceByPop = 0.02;
        private double riskOfHomelessness = 0.011;
        private double needForAdvocacyService = 0.005;
        private double riskOfAlcoholDrugProblem = 0.054929;
        private double needForChildYouthService = 0.08;

        private double communityVenuesNeededPerSA2Area = 1.75;
        private double communityClubNeededPerSA2Area = 3.2;
        private double riskForCultrualMigrantService = 0.007776;
        private double needForDisabilitySupport = 0.057;
        private double needForEducationSupport = 0.16;
        private double needForEmploymentSupport = 0.093;
        private double needForLegalAssistance = 0.004;
        private double needForSportAssistance = 0.01;

        private double averageNumberPeopleAServiceCanService = 80;

        public GapScoreServiceTask(CisDBContext dbContext)
        {
            // Retrieve a dbContext from dependency injection and assign it to a class variable
            _dbContext = dbContext;
        }

        public async Task UpdateGapScore(CancellationToken cancellationToken = default)
        {
            // Fetch all regional areas
            var regionalAreas = await _dbContext.RegionalAreaEntity.Include(area => area.Servicess).ToListAsync(cancellationToken);

            // For each regional area calculate a new gap score
            foreach (var regionalArea in regionalAreas)
            {
                var newGapScore = CalculateGap(regionalArea);
                regionalArea.GapScore = newGapScore;
            }
            // Save back to the database
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private double CalculateGap(RegionalAreaEntity regionalArea){
            // Variable to track the track score
            double gapScore = 0;

            var population = Convert.ToDouble(regionalArea.Indigenous + regionalArea.Nonindigenous);
            var services = regionalArea.Servicess.Where(service => service.Active == true);
            var servicesGroupedByCategory = services.GroupBy(service => service.Category);
            
            // Aboriginal 
            gapScore += CalculateSingleServiceGap(Categories.ABORIGINAL_SERVICE, needForAboriginalServiceByPop, regionalArea.Indigenous);
            // Accomodation
            gapScore += CalculateSingleServiceGap(Categories.ACCOMMODATION_SERVICE, riskOfHomelessness, population);
            // Advocacy  
            gapScore += CalculateSingleServiceGap(Categories.ADVOCACY_SERVICE, needForAdvocacyService, population);
            // Alcohol and Drug
            gapScore += CalculateSingleServiceGap(Categories.ALCOHOL_AND_DRUG_SERVICE, riskOfAlcoholDrugProblem, population);
            // Community facilities FIXME
            gapScore += CalculateSingleServiceGap(Categories.COMMUNITY_CENTRES_HALLS_AND_FACILITIES, communityVenuesNeededPerSA2Area, population);           
            // Community clubs FIXME
            gapScore += CalculateSingleServiceGap(Categories.COMMUNITY_CLUB, communityClubNeededPerSA2Area, population);            
            // Crisis and Emergency  TODO
            gapScore += CalculateSingleServiceGap(Categories.CRISIS_AND_EMERGENCY_SERVICE, 0, population);
            // Cultural and Migrant
            gapScore += CalculateSingleServiceGap(Categories.CULTURAL_AND_MIGRANT_SERVICE, riskForCultrualMigrantService, population);
            // Disability 
            gapScore += CalculateSingleServiceGap(Categories.DISABILITY_SERVICE, needForDisabilitySupport, population);
            // Education 
            gapScore += CalculateSingleServiceGap(Categories.EDUCATION, needForEducationSupport, population);
            // Disability 
            gapScore += CalculateSingleServiceGap(Categories.DISABILITY_SERVICE, needForDisabilitySupport, population);
            // Employment 
            gapScore += CalculateSingleServiceGap(Categories.EMPLOYMENT_AND_TRAINING, needForEmploymentSupport, population);
            // Health TODO
            gapScore += CalculateSingleServiceGap(Categories.HEALTH_SERVICE, 0, population);
            // Information and counselling TODO
            gapScore += CalculateSingleServiceGap(Categories.INFORMATION_AND_COUNSELLING, 0, population);
            // Legal
            gapScore += CalculateSingleServiceGap(Categories.LEGAL_SERVICE, needForLegalAssistance, population);
            // Self help TODO
            gapScore += CalculateSingleServiceGap(Categories.SELF_HELP, 0, population);
            // Sport
            gapScore += CalculateSingleServiceGap(Categories.SPORT, needForSportAssistance, population);
            // Welfare Assistance TODO
            gapScore += CalculateSingleServiceGap(Categories.WELFARE_ASSISTANCE, 0, population);
            // Youth
            gapScore += CalculateSingleServiceGap(Categories.YOUTH_SERVICE, needForChildYouthService, population);

            return gapScore;
        }

        private double CalculateSingleServiceGap(var categoryType, double serviceNeed, int population){
            double currentServices = Convert.ToDouble(services.Where(service => service.Category == categoryType).Count());
            double servicesNeeded = (serviceNeed * Convert.ToDouble(population)) / averageNumberPeopleAServiceCanService;
            if(currentServices < servicesNeeded){
                return (servicesNeeded - currentServices);
            }
            else return 0;
        }
    }
}
