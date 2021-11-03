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
import Footer from 'Views/Components/Footer/Footer';

// % protected region % [Add any extra imports here] off begin
import HeatMap from 'Views/Components/HeatMap/HeatMap';
import HeatMapLegend from 'Views/Components/HeatMap/HeatMapLegend';
// % protected region % [Add any extra imports here] end

export interface ServiceProfilePageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] off begin
class ServiceProfilePage extends React.Component<ServiceProfilePageProps> {
// % protected region % [Add any customisations to default class definition here] end

	// % protected region % [Add class properties here] off begin
	// % protected region % [Add class properties here] end

	render() {
		// % protected region % [Add logic before rendering contents here] off begin
		// % protected region % [Add logic before rendering contents here] end

		let contents = (
			<SecuredPage groups={['Super Administrators', 'ServiceCommissioningBody', 'Admin']}>
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
					{/* <div className="page-wrapper"> */}
						<div className="layout__horizontal">
							<h2>
								Community Services Map
							</h2>
						</div>
						<div className="layout__paragraph">
							<p>
								Like the SEIFA map, the community services map visualises which Australian regional areas
								need more funding and services. A gap score is calculated based on the current support
								the region is receiving against the required support the population needs. The higher the score, 
								the more services/ funding is needed. For a further breakdown of how the gap score is calculated for 
								each region, see <a href="/servicedashboard">Analytics Dashboard</a>.
							</p>
							<div className="map-wrapper">
								<div className="legend-wrapper">
									<HeatMapLegend></HeatMapLegend>
								</div>
								<HeatMap></HeatMap>
							</div>
						</div>
						
					{/* </div> */}
					
					{
					// % protected region % [Add code for a3ee24ec-0819-4d19-9334-ec3f0a06254f here] on begin
					}
					<div>
						<Footer />
					</div>
					{
					// % protected region % [Add code for a3ee24ec-0819-4d19-9334-ec3f0a06254f here] end
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
export default ServiceProfilePage;
// % protected region % [Override export here] end
