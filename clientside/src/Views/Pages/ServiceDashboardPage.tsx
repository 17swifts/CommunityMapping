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
import { ICollectionHeaderProps } from 'Views/Components/Collection/CollectionHeaders';
import { RegionalAreaEntity, ServiceEntity } from 'Models/Entities';
import { action, observable, runInAction } from 'mobx';
import Collection from 'Views/Components/Collection/Collection';
import axios from 'axios';
import ChartCard  from "Views/Tiles/CardTile";
import Pie from 'Views/Components/Charts/Pie';
import Doughnut from 'Views/Components/Charts/Doughnut';
import VerticalBar from 'Views/Components/Charts/VerticalBar';
import MultiType from 'Views/Components/Charts/MultiType';
import PolarChart from 'Views/Components/Charts/PolarArea';
import Footer from 'Views/Components/Footer/Footer';
// % protected region % [Add any extra imports here] end

export interface ServiceDashboardPageProps extends RouteComponentProps {
	// % protected region % [Add any extra props here] off begin
	// % protected region % [Add any extra props here] end
}

@observer
// % protected region % [Add any customisations to default class definition here] off begin
class ServiceDashboardPage extends React.Component<ServiceDashboardPageProps> {
// % protected region % [Add any customisations to default class definition here] end

	// % protected region % [Add class properties here] on begin
	@observable
	private searchTerm = { Sa2NameToSearch: "" };
	@observable
	regionalAreaSearchedBySa2Name: RegionalAreaEntity[] = [];
	emptyRegionalArea : RegionalAreaEntity = new RegionalAreaEntity({indigenous: 0, nonindigenous: 0, numofpph: 0, percentpphperday: 0, irsd: 0, irsad: 0, ieo: 0, ier: 0, australianrank: 0, servicess: Array<ServiceEntity>()});
	@observable
	regionalAreaSelected : RegionalAreaEntity = this.emptyRegionalArea;
	@observable
	selectedItem: string | undefined;

	private CustomSingleSelectionSearchCollection = () => {
		const tableHeaders: ICollectionHeaderProps<RegionalAreaEntity>[] = [
			{
				name: 'sa2Id',
				displayName: 'SA2 ID',
				transformItem: regionalAreaEntity => regionalAreaEntity.sa2id
			},
			{
				name: 'sa2Name',
				displayName: 'Regional Area Name',
				transformItem: regionalAreaEntity => regionalAreaEntity.sa2name
			},
			{
				name: 'sa3Name',
				displayName: 'SA3 Name',
				transformItem: regionalAreaEntity => regionalAreaEntity.sa3name
			}
		]

		const searchCollection = (
			<>
			<div>
				<Collection
					headers={tableHeaders}
					onSearchTriggered={this.onSearchTriggered}
					collection={this.regionalAreaSearchedBySa2Name}
					selectableItems
					itemSelectionChanged={this.itemSelectionChanged}
					getSelectedItems={() => {
						return this.regionalAreaSearchedBySa2Name.filter(x => x.sa2id === this.selectedItem);
					}}
					menuCountFunction={() => this.selectedItem === undefined ? 0 : 1}
					idColumn="Sa2id" />
			</div>
			</>
	)

		return searchCollection;
	}
	@action
	private itemSelectionChanged = (checked : boolean, changedItems : RegionalAreaEntity[]) => {
		if (checked) {
			this.selectedItem = (changedItems[0]?.sa2id);
			this.regionalAreaSelected = changedItems[0];
		} else {
			this.selectedItem = (undefined);
			this.regionalAreaSelected = this.emptyRegionalArea;
		}
		return [];
	}

	private onSearchTriggered = (searchTerm: string) => {
		axios.get('/api/entity/RegionalAreaEntity/search-regionalarea-by-name', {params: {qstr: searchTerm}})
			.then(({data}) => {
			runInAction(() => {
				this.regionalAreaSearchedBySa2Name = data;
			}
			);
		});	
	}

	// % protected region % [Add class properties here] end

	render() {
		// % protected region % [Add logic before rendering contents here] on begin
		const population = this.regionalAreaSelected.indigenous + this.regionalAreaSelected.nonindigenous;
		const investment = this.regionalAreaSelected.servicess ?
		this.regionalAreaSelected.servicess.reduce(function(prev,current){
			return prev + current.investment
		},0) : 0;

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
				<div className="scroll-body-content">
					<div className="layout__horizontal">
						<h2>
							Analytics Dashboard
						</h2>
					</div>
					{
					// % protected region % [Add code for a3b19bca-d710-4b91-8d19-45171c92b6d6 here] on begin
					}
					<div className="layout__horizontal">
						<h5> Search by Regional Area Name</h5>
					</div>
					<div className="layout__horizontal">
						{this.CustomSingleSelectionSearchCollection()}
					</div>
					<div style={{ display: 'contents' }} >
						<div className="layout__horizontal">
							<ChartCard title="Rank within Australia (SEIFA)" description="Averaged rank from the four SEIFA areas. A lower score indicates that an area is relatively disadvantaged compared to an area with a higher score (lowest score of 1, highest of 2206." statistic={this.regionalAreaSelected.australianrank} cardstyle="small"/>
							<ChartCard title="Population indexes" description={"Population: "+population} chart={<Pie labels={['Indigenous', 'Non-Indigenous']} label="Population" data={[this.regionalAreaSelected.indigenous, this.regionalAreaSelected.nonindigenous]} backgroundColor={['rgba(225, 150, 255)', 'rgba(239, 233, 242)']}/>} cardstyle="small"/>
							<ChartCard title="Potentially Preventable Hospitalisations" description=
							"PPH are defined by Admission to hospital for a condition where the hospitalisation could have potentially been prevented." statistic={this.regionalAreaSelected.numofpph+" | "+this.regionalAreaSelected.percentpphperday+"%"} cardstyle="small"/>
						</div>
						<div className="layout__horizontal">
							<ChartCard title="Active Services" chart={<Doughnut labels={['Active', 'In-Active']} label="Active Services" data={this.regionalAreaSelected.servicess? [this.regionalAreaSelected.servicess.filter(s => s.active === true).length, this.regionalAreaSelected.servicess.filter(s => s.active === false).length] : [0,0]} backgroundColor={['rgba(225, 150, 255)', 'rgba(239, 233, 242)']}/>} cardstyle="small"/>
							<ChartCard title="Total Investment" description="Services can either be funded privately or jointly between service commisioning bodies. This figure gives an indication of how much is being invested in the area on all services. It should be noted that not all funding figures are recorded so this is not an accurate figure." statistic={"$"+investment} cardstyle="small"/>
							<ChartCard title="Service Type Breakdown" chart={<VerticalBar labels={['Permanent', 'Visiting']} label="Service Type" data={this.regionalAreaSelected.servicess? [this.regionalAreaSelected.servicess.filter(s => s.servicetype === 'PERMANENT').length, this.regionalAreaSelected.servicess.filter(s => s.servicetype === 'VISITING').length]:[0,0]} backgroundColor={['rgba(225, 150, 255)', 'rgba(239, 233, 242)']}/>} cardstyle="small"/>
						</div> 
						<div className="layout__horizontal">
							<ChartCard title="Service Category Breakdown" chart={<PolarChart labels={['Aboriginal', 'Accommodation', 'Advocacy', 'Alcohol and Drug', 'Community Facilities', 'Community Club', 'Crisis and Emergency', 'Cultural and Migrant', 'Disability', 'Education', 'Employment', 'Health', 'Information and Counselling', 'Legal', 'Self Help', 'Sport', 'Welfare', 'Youth']} label='Category' 
							data={this.regionalAreaSelected.servicess? [this.regionalAreaSelected.servicess.filter(s => s.category === 'ABORIGINAL_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'ACCOMMODATION_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'ALCOHOL_AND_DRUG_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'COMMUNITY_CENTRES_HALLS_AND_FACILITIES').length, 
							this.regionalAreaSelected.servicess.filter(s => s.category === 'COMMUNITY_CLUB').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'CRISIS_AND_EMERGENCY_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'CULTURAL_AND_MIGRANT_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'DISABILITY_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'EDUCATION').length,  
							this.regionalAreaSelected.servicess.filter(s => s.category === 'EMPLOYMENT_AND_TRAINING').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'HEALTH_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'INFORMATION_AND_COUNSELLING').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'LEGAL_SERVICE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'SELF_HELP').length,  
							this.regionalAreaSelected.servicess.filter(s => s.category === 'SPORT').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'WELFARE_ASSISTANCE').length, this.regionalAreaSelected.servicess.filter(s => s.category === 'YOUTH_SERVICE').length]:[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]}
							backgroundColor={['#F0F8FF','#E6E6FA', '#D8BFD8', '#DDA0DD', '#EE82EE', '#DA70D6', '#FF00FF', '#BA55D3', '#9370DB', '#8A2BE2', '#9400D3','#9932CC','#8B008B','#800080','#4B0082', '#7B68EE', '#483D8B','#191970']}/>} cardstyle="large"/>
							
							<ChartCard title="Socio-Economic Indexes for Areas (SEIFA)" description="SEIFA ranks areas in Australia according to relative socio-economic advantage and disadvantage. The scores for all SA1s are then standardised to a distribution where the average equals 1000 and the standard deviation is 100. " 
							chart={<MultiType labels={['IRSD', 'IRSAD', 'IER', 'IEO']} label1="index score" data1={[this.regionalAreaSelected.irsd,this.regionalAreaSelected.irsad, this.regionalAreaSelected.ieo, this.regionalAreaSelected.ier]} 
							backgroundColor={['rgba(255, 191, 217)', 'rgba(255, 171, 205)', 'rgba(252, 136, 183)', 'rgba(255, 105, 166)']} type1='bar' type2='line' label2='mean' data2={[1000,1000,1000,1000]} borderColor='rgba(199, 52, 184)'/>} cardstyle="tall"/>
						</div>

					</div>
					<div>
						<Footer />
					</div>
					{
					// % protected region % [Add code for a3b19bca-d710-4b91-8d19-45171c92b6d6 here] end
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
export default ServiceDashboardPage;
// % protected region % [Override export here] end
