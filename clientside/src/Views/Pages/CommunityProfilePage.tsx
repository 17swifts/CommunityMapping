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
import Navigation, { Orientation } from 'Views/Components/Navigation/Navigation';

// % protected region % [Add any extra imports here] off begin
import 'mapbox-gl/dist/mapbox-gl.css'; // Mapbox-Gl API import
import Map from '../Components/Map/Map';
// % protected region % [Add any extra imports here] end

export interface CommunityProfilePageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] off begin
class CommunityProfilePage extends React.Component<CommunityProfilePageProps> {
// % protected region % [Add any customisations to default class definition here] end

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
							Community Profile
						</h2>
					</div>
					<div>
						<embed src="https://community-map-3418c.web.app/" style={{"width": "100%", "height": "100%" }}></embed>
					</div>
					{
					// % protected region % [Add code for 2586c999-ab9b-4685-879f-330ba2c7fab5 here] off begin
					}
					{
					// % protected region % [Add code for 2586c999-ab9b-4685-879f-330ba2c7fab5 here] end
					}
					{
					// % protected region % [Add code for d032cfa9-3e60-4118-a0ae-9acecf71f251 here] off begin
					}
					{
					// % protected region % [Add code for d032cfa9-3e60-4118-a0ae-9acecf71f251 here] end
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
export default CommunityProfilePage;
// % protected region % [Override export here] end
