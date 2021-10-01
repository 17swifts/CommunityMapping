using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis.Migrations
{
    public partial class _1633052887 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,arts_and_creatives,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,health_service,information_and_counselling,legal_service,religion_and_philosophy,self_help,sport,transport_service,welfare_assistance,youth_service")
                .Annotation("Npgsql:Enum:gender", "female,male,other,both")
                .Annotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .OldAnnotation("Npgsql:Enum:gender", "female,male,other,both")
                .OldAnnotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .Annotation("Npgsql:Enum:gender", "female,male,other,both")
                .Annotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,arts_and_creatives,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,health_service,information_and_counselling,legal_service,religion_and_philosophy,self_help,sport,transport_service,welfare_assistance,youth_service")
                .OldAnnotation("Npgsql:Enum:gender", "female,male,other,both")
                .OldAnnotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
