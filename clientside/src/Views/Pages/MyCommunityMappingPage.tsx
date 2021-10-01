/*
 * @bot-written
 *
 * WARNING AND NOTICE
 * Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
 * Full Software Licence as accepted by you before being granted access to this source code and other materials,
 * the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
 * commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
 * licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
 * including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
 * access, download, storage, and/or use of this source code.
 *
 * BOT WARNING
 * This file is bot-written.
 * Any changes out side of "protected regions" will be lost next time the bot makes any changes.
 */
import * as React from 'react';
import SecuredPage from 'Views/Components/Security/SecuredPage';
import { observer } from 'mobx-react';
import { RouteComponentProps } from 'react-router';
import { getFrontendNavLinks } from 'Views/FrontendNavLinks';
import { Button } from 'Views/Components/Button/Button';
import Navigation, { Orientation } from 'Views/Components/Navigation/Navigation';

// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

export interface MyCommunityMappingPageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] off begin
class MyCommunityMappingPage extends React.Component<MyCommunityMappingPageProps> {
// % protected region % [Add any customisations to default class definition here] end

	// % protected region % [Override onCommunityProfileClick here] off begin
	onCommunityProfileClick: React.MouseEventHandler<HTMLButtonElement> = (e) => {
	}
	// % protected region % [Override onCommunityProfileClick here] end

	// % protected region % [Override onServiceProfileClick here] off begin
	onServiceProfileClick: React.MouseEventHandler<HTMLButtonElement> = (e) => {
	}
	// % protected region % [Override onServiceProfileClick here] end

	// % protected region % [Add class properties here] off begin
	// % protected region % [Add class properties here] end

	render() {
		// % protected region % [Add logic before rendering contents here] off begin
		// % protected region % [Add logic before rendering contents here] end

		let contents = (
			<SecuredPage>
				{
				// % protected region % [Alter navigation here] off begin
				}
				<Navigation
					linkGroups={getFrontendNavLinks(this.props)}
					orientation={Orientation.VERTICAL}
					match={this.props.match}
					location={this.props.location}
					history={this.props.history}
					staticContext={this.props.staticContext}
				/>
				{
				// % protected region % [Alter navigation here] end
				}
				<div className="body-content">
					<div className="layout__horizontal">
						<h2>
							My Community Mapping
						</h2>
					</div>
					<div className="layout__horizontal">
						<Button onClick={this.onServiceProfileClick} >
							Community Services Map
						</Button>
						<Button onClick={this.onCommunityProfileClick} >
							SEIFA Index Map
						</Button>
					</div>
					<div className="layout__horizontal">
						<p>
							...
						</p>
						<h5>
							What is My Community Mapping
						</h5>
					</div>
					<div className="layout__horizontal">
						<p>
							Supported By
						</p>
					</div>
					{
					// % protected region % [Add code for f597d2a9-5cee-4646-bd24-8c4b0c15624b here] off begin
					}
					{
					// % protected region % [Add code for f597d2a9-5cee-4646-bd24-8c4b0c15624b here] end
					}
				</div>
			</SecuredPage>
		);

		// % protected region % [Override contents here] off begin
		// % protected region % [Override contents here] end

		return contents;
	}
}

// % protected region % [Override export here] off begin
export default MyCommunityMappingPage;
// % protected region % [Override export here] end
