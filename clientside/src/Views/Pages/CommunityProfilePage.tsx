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

// % protected region % [Add any extra imports here] on begin
import Map from 'Views/Components/Map/Map';
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
					<div className="page-wrapper">
						<div className="header">
							<h2>
								SEIFA Indexes Map
							</h2>
						</div>
						<div className="body">
							<div>
								<p>
									Socio-Economic Indexes for Areas (SEIFA) ranks areas in Australia according to relative socio-economic 
									advantage and disadvantage. This map can be used to help visualise which areas in Australia require more 
									funding and services. Areas can also be selected and compared graphically. 
								</p>
								<p>
									The four indexes are the following:
									<ul>
										<li>The Index of Relative Socio-Economic Disadvantage (IRSD)</li>
										<li>The Index of Relative Socio-Economic Advantage and Disadvantage (IRSAD)</li>
										<li>The Index of Education and Occupation (IEO)</li>
										<li>The Index of Economic Resources (IER). </li>
									</ul>
								</p>
							</div>
							<div className="map-wrapper">
								<Map></Map>
							</div>
						</div>
					</div>
					{
					// % protected region % [Add code for 2586c999-ab9b-4685-879f-330ba2c7fab5 here] on begin
					}
					
					{
					// % protected region % [Add code for 2586c999-ab9b-4685-879f-330ba2c7fab5 here] end
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
