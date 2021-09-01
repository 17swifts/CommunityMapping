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

Feature: Sort RegionalAreaEntity
	@RegionalAreaEntity
	Scenario: Sort RegionalAreaEntity
	Given I login to the site as a user
	And I navigate to the RegionalAreaEntity backend page
	When I sort RegionalAreaEntity by sa2Id
	Then I assert that sa2Id in RegionalAreaEntity of type String is properly sorted in descending
	When I sort RegionalAreaEntity by sa2Id
	Then I assert that sa2Id in RegionalAreaEntity of type String is properly sorted in ascending
	When I sort RegionalAreaEntity by sa3Id
	Then I assert that sa3Id in RegionalAreaEntity of type String is properly sorted in descending
	When I sort RegionalAreaEntity by sa3Id
	Then I assert that sa3Id in RegionalAreaEntity of type String is properly sorted in ascending
	When I sort RegionalAreaEntity by sa3Name
	Then I assert that sa3Name in RegionalAreaEntity of type String is properly sorted in descending
	When I sort RegionalAreaEntity by sa3Name
	Then I assert that sa3Name in RegionalAreaEntity of type String is properly sorted in ascending
	When I sort RegionalAreaEntity by numOfPph
	Then I assert that numOfPph in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by numOfPph
	Then I assert that numOfPph in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by percentPphPerDay
	Then I assert that percentPphPerDay in RegionalAreaEntity of type double is properly sorted in descending
	When I sort RegionalAreaEntity by percentPphPerDay
	Then I assert that percentPphPerDay in RegionalAreaEntity of type double is properly sorted in ascending
	When I sort RegionalAreaEntity by sa2Name
	Then I assert that sa2Name in RegionalAreaEntity of type String is properly sorted in descending
	When I sort RegionalAreaEntity by sa2Name
	Then I assert that sa2Name in RegionalAreaEntity of type String is properly sorted in ascending
	When I sort RegionalAreaEntity by indigenous
	Then I assert that indigenous in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by indigenous
	Then I assert that indigenous in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by nonIndigenous
	Then I assert that nonIndigenous in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by nonIndigenous
	Then I assert that nonIndigenous in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by irsd
	Then I assert that irsd in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by irsd
	Then I assert that irsd in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by irsad
	Then I assert that irsad in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by irsad
	Then I assert that irsad in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by ier
	Then I assert that ier in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by ier
	Then I assert that ier in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by ieo
	Then I assert that ieo in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by ieo
	Then I assert that ieo in RegionalAreaEntity of type int is properly sorted in ascending
	When I sort RegionalAreaEntity by gap Score
	Then I assert that gap Score in RegionalAreaEntity of type double is properly sorted in descending
	When I sort RegionalAreaEntity by gap Score
	Then I assert that gap Score in RegionalAreaEntity of type double is properly sorted in ascending
	When I sort RegionalAreaEntity by AustralianRank
	Then I assert that AustralianRank in RegionalAreaEntity of type int is properly sorted in descending
	When I sort RegionalAreaEntity by AustralianRank
	Then I assert that AustralianRank in RegionalAreaEntity of type int is properly sorted in ascending

