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
Feature: View readonly ServiceEntity
# % protected region % [Override feature properties here] end
# % protected region % [Override test contents here] off begin
	@ServiceEntity
	Scenario: View ServiceEntity
	Given I login to the site as a user
	And I insert a ServiceEntity into the database
	And I navigate to the ServiceEntity admin crud page
	When I click View on the first ServiceEntity in the crud list
	Then I assert that I am viewing a ServiceEntity on the ServiceEntity view page
# % protected region % [Override test contents here] end

# % protected region % [Add any additional tests here] off begin
# % protected region % [Add any additional tests here] end