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
# % protected region % [Override feature properties here] off begin
@sorting @BotWritten @ignore
# WARNING: These Tests have been flagged as unstable and have been ignored until they are updated.
# % protected region % [Override feature properties here] end

Feature: Sort ServiceEntity
	@ServiceEntity
	Scenario: Sort ServiceEntity
	Given I login to the site as a user
	And I navigate to the ServiceEntity backend page
	When I sort ServiceEntity by Name
	Then I assert that Name in ServiceEntity of type String is properly sorted in descending
	When I sort ServiceEntity by Name
	Then I assert that Name in ServiceEntity of type String is properly sorted in ascending
	When I sort ServiceEntity by Description
	Then I assert that Description in ServiceEntity of type String is properly sorted in descending
	When I sort ServiceEntity by Description
	Then I assert that Description in ServiceEntity of type String is properly sorted in ascending
	When I sort ServiceEntity by ServiceType
	Then I assert that ServiceType in ServiceEntity of type String is properly sorted in descending
	When I sort ServiceEntity by ServiceType
	Then I assert that ServiceType in ServiceEntity of type String is properly sorted in ascending
	When I sort ServiceEntity by Category
	Then I assert that Category in ServiceEntity of type String is properly sorted in descending
	When I sort ServiceEntity by Category
	Then I assert that Category in ServiceEntity of type String is properly sorted in ascending
	When I sort ServiceEntity by Active
	Then I assert that Active in ServiceEntity of type bool is properly sorted in descending
	When I sort ServiceEntity by Active
	Then I assert that Active in ServiceEntity of type bool is properly sorted in ascending
	When I sort ServiceEntity by NoServiceDays
	Then I assert that NoServiceDays in ServiceEntity of type int is properly sorted in descending
	When I sort ServiceEntity by NoServiceDays
	Then I assert that NoServiceDays in ServiceEntity of type int is properly sorted in ascending
	When I sort ServiceEntity by Investment
	Then I assert that Investment in ServiceEntity of type double is properly sorted in descending
	When I sort ServiceEntity by Investment
	Then I assert that Investment in ServiceEntity of type double is properly sorted in ascending
	When I sort ServiceEntity by StartDate
	Then I assert that StartDate in ServiceEntity of type Date is properly sorted in descending
	When I sort ServiceEntity by StartDate
	Then I assert that StartDate in ServiceEntity of type Date is properly sorted in ascending
	When I sort ServiceEntity by EndDate
	Then I assert that EndDate in ServiceEntity of type Date is properly sorted in descending
	When I sort ServiceEntity by EndDate
	Then I assert that EndDate in ServiceEntity of type Date is properly sorted in ascending
	When I sort ServiceEntity by Gender
	Then I assert that Gender in ServiceEntity of type String is properly sorted in descending
	When I sort ServiceEntity by Gender
	Then I assert that Gender in ServiceEntity of type String is properly sorted in ascending
	When I sort ServiceEntity by AgeMin
	Then I assert that AgeMin in ServiceEntity of type int is properly sorted in descending
	When I sort ServiceEntity by AgeMin
	Then I assert that AgeMin in ServiceEntity of type int is properly sorted in ascending
	When I sort ServiceEntity by AgeMax
	Then I assert that AgeMax in ServiceEntity of type int is properly sorted in descending
	When I sort ServiceEntity by AgeMax
	Then I assert that AgeMax in ServiceEntity of type int is properly sorted in ascending

