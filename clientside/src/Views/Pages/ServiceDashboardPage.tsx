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
import { RegionalAreaEntity } from 'Models/Entities';
import { observable, runInAction } from 'mobx';
import Collection from 'Views/Components/Collection/Collection';
import axios from 'axios';
import ChartTile from "Views/Tiles/ChartTile";
import ChartCard  from "Views/Tiles/CardTile";
import Pie from 'Views/Components/Charts/Pie';
import VerticalBar from 'Views/Components/Charts/VerticalBar';
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
	@observable
	regionalAreaSelected : RegionalAreaEntity;
	population : number[] = [0,0];

	// Chart data
	populationData = [0,0];

	private CustomSingleSelectionSearchCollection = () => {
		const tableHeaders: ICollectionHeaderProps<RegionalAreaEntity>[] = [
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

		let selectedItem: string | undefined;

		const searchCollection = (
			<>
			<h5> Search by Regional Area Name</h5>
			<Collection
				headers={tableHeaders}
				onSearchTriggered={this.onSearchTriggered}
				collection={this.regionalAreaSearchedBySa2Name}
				selectableItems
				itemSelectionChanged={((checked, changedItems) => {
					if (checked) {
						selectedItem = (changedItems[0]?.sa2name);
						this.population = [changedItems[0].indigenous, changedItems[0].nonindigenous];
						this.regionalAreaSelected = changedItems[0];
						return [changedItems[0]];
					} else {
						selectedItem = (undefined);
						return [];
					}
				})}
				getSelectedItems={() => {
					return [this.regionalAreaSearchedBySa2Name.find(x => x.sa2name === selectedItem)!];
				}}
				menuCountFunction={() => selectedItem === undefined ? 0 : 1}
				idColumn="Sa2id" />
				</>
	)

		return searchCollection;
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

	private displayCharts(){
		const charts = (
			<>
			<div>
				<ChartCard title="Population indexes" chart={<Pie labels={['Indigenous', 'Non-Indigenous']} label="Population" data={[this.regionalAreaSelected.indigenous,this.regionalAreaSelected.nonindigenous]} backgroundColor={['rgba(225, 150, 255)', 'rgba(239, 233, 242)']}/>}/>
				<ChartCard title="Socio-Economic Indexes for Areas (SEIFA)" description="SEIFA ranks areas in Australia according to relative socio-economic advantage and disadvantage." chart={<VerticalBar labels={['IRSD', 'IRSAD', 'IER', 'IEO']} label="SIEFA" data={[this.regionalAreaSelected.irsd,this.regionalAreaSelected.irsad, this.regionalAreaSelected.ieo, this.regionalAreaSelected.ier]} backgroundColor={['rgba(255, 191, 217)', 'rgba(255, 171, 205)', 'rgba(252, 136, 183)', 'rgba(255, 105, 166)']}/>}/>
			</div>
			</>
		)
		return charts;
	}

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
					<div className="layout__horizontal">
						<h2>
							Analytics Dashboard
						</h2>
					</div>
					{
					// % protected region % [Add code for a3b19bca-d710-4b91-8d19-45171c92b6d6 here] on begin
					}
					<div className="layout__horizontal">
						{this.CustomSingleSelectionSearchCollection()}
					</div>
					<div className="layout__horizontal">
						 {/* <ChartCard title="Active services" chart={<ChartTile {...this.props}/>}/> */}
						 {/* <ChartCard title="Socio-Economic Indexes for Areas (SEIFA)" description="SEIFA ranks areas in Australia according to relative socio-economic advantage and disadvantage." chart={<VerticalBar labels={['IRSD', 'IRSAD', 'IER', 'IEO']} label="SIEFA" data={[this.regionalAreaSelected.irsd,this.regionalAreaSelected.irsad, this.regionalAreaSelected.ieo, this.regionalAreaSelected.ier]} backgroundColor={['rgba(255, 191, 217)', 'rgba(255, 171, 205)', 'rgba(252, 136, 183)', 'rgba(255, 105, 166)']}/>}/> */}
						 <ChartCard title="Socio-Economic Indexes for Areas (SEIFA)" description="SEIFA ranks areas in Australia according to relative socio-economic advantage and disadvantage." chart={<VerticalBar labels={['IRSD', 'IRSAD', 'IER', 'IEO']} label="SIEFA" data={[100,230, 86, 345]} backgroundColor={['rgba(255, 191, 217)', 'rgba(255, 171, 205)', 'rgba(252, 136, 183)', 'rgba(255, 105, 166)']}/>}/>
						 <ChartCard title="Population indexes" chart={<Pie labels={['Indigenous', 'Non-Indigenous']} label="Population" data={this.population} backgroundColor={['rgba(225, 150, 255)', 'rgba(239, 233, 242)']}/>}/>
						 <ChartCard title="Potentially Preventable Hospitalisations" description=
						 "PPH are defined by Admission to hospital for a condition where the hospitalisation could have potentially been prevented." statistic="980 | 0.32%"/>
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
