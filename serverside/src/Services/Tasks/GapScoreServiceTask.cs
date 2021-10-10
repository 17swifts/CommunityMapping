using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        private double communityVenuesNeededPerSA2Area = 0.002;
        private double communityClubNeededPerSA2Area = 0.03;
        private double riskForCultrualMigrantService = 0.007776;
        private double needForDisabilitySupport = 0.057;
        private double needForEducationSupport = 0.16;
        private double needForEmploymentSupport = 0.093;
        private double needForLegalAssistance = 0.004;
        private double needForSportAssistance = 0.01;
        private double needForCouncelling = 0.105;
        private double needForSelfHelp = 0.21;
        private double needForWelfareAssitance = 0.12;
        private double neeedForHealthServices = 0.25;

        private double averageNumberPeopleAServiceCanService = 120;

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
            gapScore += CalculateSingleServiceGap(services, Categories.ABORIGINAL_SERVICE, needForAboriginalServiceByPop, Convert.ToDouble(regionalArea.Indigenous));
            // Accomodation
            gapScore += CalculateSingleServiceGap(services, Categories.ACCOMMODATION_SERVICE, riskOfHomelessness, population);
            // Advocacy  
            gapScore += CalculateSingleServiceGap(services, Categories.ADVOCACY_SERVICE, needForAdvocacyService, population);
            // Alcohol and Drug
            gapScore += CalculateSingleServiceGap(services, Categories.ALCOHOL_AND_DRUG_SERVICE, riskOfAlcoholDrugProblem, population);
            // Community facilities
            gapScore += CalculateSingleServiceGap(services, Categories.COMMUNITY_CENTRES_HALLS_AND_FACILITIES, communityVenuesNeededPerSA2Area, population);           
            // Community clubs
            gapScore += CalculateSingleServiceGap(services, Categories.COMMUNITY_CLUB, communityClubNeededPerSA2Area, population);            
            // Crisis and Emergency  TODO
            gapScore += CalculateSingleServiceGap(services, Categories.CRISIS_AND_EMERGENCY_SERVICE, 0, population);
            // Cultural and Migrant
            gapScore += CalculateSingleServiceGap(services, Categories.CULTURAL_AND_MIGRANT_SERVICE, riskForCultrualMigrantService, population);
            // Disability 
            gapScore += CalculateSingleServiceGap(services, Categories.DISABILITY_SERVICE, needForDisabilitySupport, population);
            // Education 
            gapScore += CalculateSingleServiceGap(services, Categories.EDUCATION, needForEducationSupport, population);
            // Disability 
            gapScore += CalculateSingleServiceGap(services, Categories.DISABILITY_SERVICE, needForDisabilitySupport, population);
            // Employment 
            gapScore += CalculateSingleServiceGap(services, Categories.EMPLOYMENT_AND_TRAINING, needForEmploymentSupport, population);
            // Health TODO
            gapScore += CalculateSingleServiceGap(services, Categories.HEALTH_SERVICE, neeedForHealthServices, population);
            // Information and counselling
            gapScore += CalculateSingleServiceGap(services, Categories.INFORMATION_AND_COUNSELLING, needForCouncelling, population);
            // Legal
            gapScore += CalculateSingleServiceGap(services, Categories.LEGAL_SERVICE, needForLegalAssistance, population);
            // Self help
            gapScore += CalculateSingleServiceGap(services, Categories.SELF_HELP, needForSelfHelp, population);
            // Sport
            gapScore += CalculateSingleServiceGap(services, Categories.SPORT, needForSportAssistance, population);
            // Welfare Assistance
            gapScore += CalculateSingleServiceGap(services, Categories.WELFARE_ASSISTANCE, needForWelfareAssitance, population);
            // Youth
            gapScore += CalculateSingleServiceGap(services, Categories.YOUTH_SERVICE, needForChildYouthService, population);

            return gapScore;
        }

        private double CalculateSingleServiceGap(IEnumerable<ServiceEntity> services, Categories categoryType, double serviceNeed, double population){
            double currentServices = Convert.ToDouble(services.Where(service => service.Category == categoryType).Count());
            double servicesNeeded = (serviceNeed * population) / averageNumberPeopleAServiceCanService;
            if(currentServices < servicesNeeded){
                return (servicesNeeded - currentServices);
            }
            else return 0;
        }
    }
}
