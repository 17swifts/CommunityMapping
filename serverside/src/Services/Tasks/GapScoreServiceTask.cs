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
            var regionalAreas = await _dbContext.RegionalAreaEntity.ToListAsync(cancellationToken);

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
            var services = regionalArea.Servicess;
            var servicesGroupedByCategory = services.Where(service => service.Active == true)
                .GroupBy(service => service.Category);
            
            foreach(var group in servicesGroupedByCategory){
                double currentServices = Convert.ToDouble(group.Count());
                double servicesNeeded = 0;
                switch(group.Key)
                {
                case Categories.ABORIGINAL_SERVICE:
                    servicesNeeded = (needForAboriginalServiceByPop * Convert.ToDouble(regionalArea.Indigenous)) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.ACCOMMODATION_SERVICE:
                    servicesNeeded = (riskOfHomelessness * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.ADVOCACY_SERVICE:
                    servicesNeeded = (needForAdvocacyService * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.ALCOHOL_AND_DRUG_SERVICE:
                    servicesNeeded = (riskOfAlcoholDrugProblem * population) / averageNumberPeopleAServiceCanService;
                    break;   
                case Categories.COMMUNITY_CENTRES_HALLS_AND_FACILITIES:
                    servicesNeeded = communityVenuesNeededPerSA2Area;
                    break;
                case Categories.COMMUNITY_CLUB:
                    servicesNeeded = communityClubNeededPerSA2Area;
                    break;
                case Categories.CRISIS_AND_EMERGENCY_SERVICE:

                    break;
                case Categories.CULTURAL_AND_MIGRANT_SERVICE:
                    servicesNeeded = (riskForCultrualMigrantService * population) / averageNumberPeopleAServiceCanService;                   
                    break;
                case Categories.DISABILITY_SERVICE:
                    servicesNeeded = (needForDisabilitySupport * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.EDUCATION:
                    servicesNeeded = (needForEducationSupport * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.EMPLOYMENT_AND_TRAINING:
                    servicesNeeded = (needForEmploymentSupport * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.HEALTH_SERVICE:
                    
                    break;
                case Categories.INFORMATION_AND_COUNSELLING:
                    
                    break;
                case Categories.LEGAL_SERVICE:
                    servicesNeeded = (needForLegalAssistance * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.SELF_HELP:

                    break;
                case Categories.SPORT:
                    servicesNeeded = (needForSportAssistance * population) / averageNumberPeopleAServiceCanService;
                    break;
                case Categories.WELFARE_ASSISTANCE:

                    break;
                case Categories.YOUTH_SERVICE:
                    servicesNeeded = (needForChildYouthService * population) / averageNumberPeopleAServiceCanService;
                    break;
                default:
                    // code block
                    break;
                }

                if(currentServices < servicesNeeded){
                    gapScore += (servicesNeeded - currentServices);
                }
            }
            return gapScore;
        }
    }
}
