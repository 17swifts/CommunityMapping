###
# @bot-written
#
# WARNING AND NOTICE
# Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
# Full Software Licence as accepted by you before being granted access to this source code and other materials,
# the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
# commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
# licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
# including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
# access, download, storage, and/or use of this source code.
#
# BOT WARNING
# This file is bot-written.
# Any changes out side of "protected regions" will be lost next time the bot makes any changes.
###
@sorting @BotWritten @ignore
# WARNING: These Tests have been flagged as unstable and have been ignored until they are updated.

Feature: Sort RegionalAreaEntity
	@RegionalAreaEntity
	Scenario: Sort RegionalAreaEntity
	Given I login to the site as a user
	And I navigate to the RegionalAreaEntity backend page
	When I sort RegionalAreaEntity by Name
	Then I assert that Name in RegionalAreaEntity of type String is properly sorted in descending
	When I sort RegionalAreaEntity by Name
	Then I assert that Name in RegionalAreaEntity of type String is properly sorted in ascending
	When I sort RegionalAreaEntity by NonIndigenousPopulation
	Then I assert that NonIndigenousPopulation in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by NonIndigenousPopulation
	Then I assert that NonIndigenousPopulation in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by IndigenousPopulation
	Then I assert that IndigenousPopulation in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by IndigenousPopulation
	Then I assert that IndigenousPopulation in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by PPH
	Then I assert that PPH in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by PPH
	Then I assert that PPH in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by IRSD
	Then I assert that IRSD in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by IRSD
	Then I assert that IRSD in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by IRSAD
	Then I assert that IRSAD in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by IRSAD
	Then I assert that IRSAD in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by IEO
	Then I assert that IEO in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by IEO
	Then I assert that IEO in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by IER
	Then I assert that IER in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by IER
	Then I assert that IER in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by Gap Score
	Then I assert that Gap Score in RegionalAreaEntity of type double is properly sorted in descending
	When I sort RegionalAreaEntity by Gap Score
	Then I assert that Gap Score in RegionalAreaEntity of type double is properly sorted in ascending

