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
import cissLogo from '../../assets/img/CISSLogo.png';
import WAGov from '../../assets/img/WAGov.png';
import QLDGov from '../../assets/img/QLDGov.png';
import ACTGov from '../../assets/img/ACTGov.svg';
import CommunityImg from '../../assets/img/regionalarea.jpg';
import ServiceImg from '../../assets/img/community.jpg';
import Footer from '../Components/Footer/Footer';
// % protected region % [Add any extra imports here] end

export interface MyCommunityMappingPageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] off begin
class MyCommunityMappingPage extends React.Component<MyCommunityMappingPageProps> {
// % protected region % [Add any customisations to default class definition here] end

	// % protected region % [Override onCommunityProfileClick here] on begin
	onCommunityProfileClick: React.MouseEventHandler<HTMLButtonElement> = (e) => {
		this.props.history.push('/communityprofile');
	}
	// % protected region % [Override onCommunityProfileClick here] end

	// % protected region % [Override onServiceProfileClick here] off begin
	onServiceProfileClick: React.MouseEventHandler<HTMLButtonElement> = (e) => {
		this.props.history.push('/serviceprofile');
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
					<div className="layout__paragraph">
						<h4>
							EXPLORE OUR MAPS
						</h4>
					</div>
					<div className="layout__horizontal">
						<div className="container">
							<img src={CommunityImg} alt="Community Profile" className="image"/>
							<div className="overlay">
								<a href="/communityprofile">
									<div className="text" >SEIFA Index Map</div>
								</a>
							</div>
						</div>
						<div className="container">
							<img src={ServiceImg} alt="Service Profile" className="image"/>
							<div className="overlay">
								<a href="/serviceprofile">
									<div className="text">Community Services Map</div>
								</a>
							</div>
						</div>
					</div>
					<div className="layout__paragraph">
						<h5>
							WHAT IS MY COMMUNITY MAPPING
						</h5>
					</div>
					<div className="layout__paragraph">
						<p>
							My Community Mapping was built in conjunction with My Community Directory 
							and My Community Diary as a premier source of connection between Government, 
							community organisations, and the public. Our vision is to support the future 
							public health needs of an entire region by leading the development of digital 
							infrastructure to enable better matching, planning and provision of health and 
							community services to meet individual and emerging community needs. 
						</p>
					</div>

					<div className="layout__paragraph">
						<p>
							Supported By
						</p>
					</div>
					<div className="layout__horizontal">
						<a href="http://www.communityinfo.org.au/">
							<img src={cissLogo} alt="Community Information Support Services" width="200" height="100"></img>
						</a>
						<img src={WAGov} alt="Government of Western Australia" width="100" height="100"></img>
						<img src={QLDGov} alt="Queensland Government" width="100" height="100"></img>
						<img src={ACTGov} alt="ACT Government" width="100" height="100"></img>
					</div>
					{
					// % protected region % [Add code for f597d2a9-5cee-4646-bd24-8c4b0c15624b here] off begin
					}
					<div>
						<Footer />
					</div>
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
