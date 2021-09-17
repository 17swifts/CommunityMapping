import * as React from 'react';
import { observer } from 'mobx-react';
import { RouteComponentProps } from 'react-router';

import {computed, observable, runInAction} from "mobx";
import {gql} from '@apollo/client';
import {store} from "Models/Store";
import { Doughnut } from 'react-chartjs-2';
import Spinner from "Views/Components/Spinner/Spinner";

@observer
export default class ChartTile extends React.Component<RouteComponentProps> {

    
    @observable
    private activeServicesCount : number | undefined = undefined;

    @observable
    private totalServicesCount : number | undefined = undefined;

    @computed
    private get inactiveServicesCount() {
        if (this.totalServicesCount != undefined && this.activeServicesCount != undefined){
            return this.totalServicesCount - this.activeServicesCount;
        }
        return undefined;
    }

    @observable
    private loadingState : 'loading' | 'done' | 'error' = 'loading';

    @observable
    private error : any;

    private activeServiceCountQuery = gql`
        query getData {
            countServiceEntitys(where: [{path: "active", value: "true"}]) {
            number
        }
    }`;

    private totalServiceCountQuery = gql`
        query getData {
            countServiceEntitys {
            number
        }
    }`;

    
	async componentDidMount() {
		this.getServiceCount(this.activeServiceCountQuery).then(result => runInAction(() => this.activeServicesCount = result));
		this.getServiceCount(this.totalServiceCountQuery).then(result => runInAction(() => this.totalServicesCount = result));
		runInAction(() => this.loadingState = 'done');
	}

	private getServiceCount = async (serviceCountQuery : any) => {
		return store.apolloClient
			.query({
				query: serviceCountQuery,
				fetchPolicy: 'network-only',
			})
			.then((r: { data: { countServiceEntitys: { number: any; }; }; }) => {
				return r.data.countServiceEntitys.number;
			})
			.catch((e: any) => {
				runInAction(() => {
					this.error = e;
					return undefined;
				})
			});
	};

	private serviceCountGraph = () => {
		if (this.loadingState == 'done' && this.activeServicesCount!= undefined && this.inactiveServicesCount!= undefined){
			return (<Doughnut
						data={{
								labels: ['Active Services', 'Inactive Services'],
								datasets:[{
									data: [this.activeServicesCount, this.inactiveServicesCount],
									backgroundColor: ['rgba(182,122,255,0.2)', 'rgba(255,255,255,0.2)']
								}]
						}}/>);
		}
		return Spinner();
	};
	


	public render() {
		let contents = null;
        
		contents = (
			<div className={'active-service-graph'}>
				{this.serviceCountGraph()}
			</div>
		);

		return contents;
	}

}
