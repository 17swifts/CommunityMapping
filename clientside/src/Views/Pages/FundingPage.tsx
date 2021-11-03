import * as React from 'react';
import SecuredPage from 'Views/Components/Security/SecuredPage';
import { observer } from 'mobx-react';
import { RouteComponentProps } from 'react-router';
import { getFrontendNavLinks } from 'Views/FrontendNavLinks';
import Navigation, { Orientation } from 'Views/Components/Navigation/Navigation';

// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

export interface FundingPageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] on begin
class FundingPage extends React.Component<FundingPageProps> {
// % protected region % [Add any customisations to default class definition here] end

	// % protected region % [Add class properties here] off begin
	// % protected region % [Add class properties here] end

	render() {
		// % protected region % [Add logic before rendering contents here] off begin
		// % protected region % [Add logic before rendering contents here] end

		let contents = (
			<SecuredPage>
				{
				// % protected region % [Alter navigation here] on begin
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
							    Funding (In Progress)
						    </h2>
                        </div>
					</div>
				</div>
			</SecuredPage>
		);

		// % protected region % [Override contents here] off begin
		// % protected region % [Override contents here] end

		return contents;
	}
}

// % protected region % [Override export here] off begin
export default FundingPage;
// % protected region % [Override export here] end