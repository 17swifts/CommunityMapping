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
@BotWritten @view
Feature: View readonly RegionalAreaEntity
# % protected region % [Override feature properties here] end
# % protected region % [Override test contents here] off begin
	@RegionalAreaEntity
	Scenario: View RegionalAreaEntity
	Given I login to the site as a user
	And I insert a RegionalAreaEntity into the database
	And I navigate to the RegionalAreaEntity admin crud page
	When I click View on the first RegionalAreaEntity in the crud list
	Then I assert that I am viewing a RegionalAreaEntity on the RegionalAreaEntity view page
# % protected region % [Override test contents here] end

# % protected region % [Add any additional tests here] off begin
# % protected region % [Add any additional tests here] end