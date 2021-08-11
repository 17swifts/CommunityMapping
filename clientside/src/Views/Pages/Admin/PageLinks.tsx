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
import Navigation, { Orientation, ILink } from 'Views/Components/Navigation/Navigation';
import { RouteComponentProps } from 'react-router';
import * as Models from 'Models/Entities';
import { Model } from 'Models/Model';
import { IIconProps } from "Views/Components/Helpers/Common";
import { SecurityService } from "Services/SecurityService";
import { getModelDisplayName } from 'Util/EntityUtils';
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

interface AdminLink extends IIconProps {
	path: string;
	label: string;
	entity: {new (args: any): Model};
	isMember?: boolean;
	// % protected region % [Add extra AdminLink fields here] off begin
	// % protected region % [Add extra AdminLink fields here] end
}

const getPageLinks = (): AdminLink[] => [
	{
		// % protected region % [Override navigation link for AdminEntity here] off begin
		path: '/admin/adminentity',
		label: getModelDisplayName(Models.AdminEntity),
		entity: Models.AdminEntity,
		isMember: true
		// % protected region % [Override navigation link for AdminEntity here] end
	},
	{
		// % protected region % [Override navigation link for RegionalAreaEntity here] off begin
		path: '/admin/regionalareaentity',
		label: getModelDisplayName(Models.RegionalAreaEntity),
		entity: Models.RegionalAreaEntity,
		isMember: false
		// % protected region % [Override navigation link for RegionalAreaEntity here] end
	},
	{
		// % protected region % [Override navigation link for ServiceEntity here] off begin
		path: '/admin/serviceentity',
		label: getModelDisplayName(Models.ServiceEntity),
		entity: Models.ServiceEntity,
		isMember: false
		// % protected region % [Override navigation link for ServiceEntity here] end
	},
	{
		// % protected region % [Override navigation link for ServiceCommissioningBodyEntity here] off begin
		path: '/admin/servicecommissioningbodyentity',
		label: getModelDisplayName(Models.ServiceCommissioningBodyEntity),
		entity: Models.ServiceCommissioningBodyEntity,
		isMember: true
		// % protected region % [Override navigation link for ServiceCommissioningBodyEntity here] end
	},
	{
		// % protected region % [Override navigation link for MetricEntity here] off begin
		path: '/admin/metricentity',
		label: getModelDisplayName(Models.MetricEntity),
		entity: Models.MetricEntity,
		isMember: false
		// % protected region % [Override navigation link for MetricEntity here] end
	},
	{
		// % protected region % [Override navigation link for RegionalAreaTimelineEventsEntity here] off begin
		path: '/admin/regionalareatimelineeventsentity',
		label: getModelDisplayName(Models.RegionalAreaTimelineEventsEntity),
		entity: Models.RegionalAreaTimelineEventsEntity,
		isMember: false
		// % protected region % [Override navigation link for RegionalAreaTimelineEventsEntity here] end
	},
	// % protected region % [Add any extra page links here] off begin
	// % protected region % [Add any extra page links here] end
];

export default class PageLinks extends React.Component<RouteComponentProps> {
	private filter = (link: AdminLink) => {
		return SecurityService.canRead(link.entity);
	}

	public render() {
		return <Navigation
			className='nav__admin'
			orientation={Orientation.VERTICAL}
			linkGroups={this.getAdminNavLinks()}
			{...this.props} />;
	}

	private getAdminNavLinks = () : ILink[][] => {
		// % protected region % [Add custom logic before all here] off begin
		// % protected region % [Add custom logic before all here] end

		const links = getPageLinks();
		let userLinks = links.filter(link => link.isMember).filter(this.filter);
		let entityLinks = links.filter(link => ! link.isMember).filter(this.filter);

		let linkGroups: ILink[][] = [];

		// % protected region % [Add any custom logic here before groups are made] off begin
		// % protected region % [Add any custom logic here before groups are made] end

		const homeLinkGroup: ILink[] = [
			{ path: '/admin', label: 'Home', icon: 'home', iconPos: 'icon-left' },
			// % protected region % [Updated your home link group here] off begin
			// % protected region % [Updated your home link group here] end
		];
		linkGroups.push(homeLinkGroup);

		const entityLinkGroup: ILink[] = [];
		if (userLinks.length > 0) {
			entityLinkGroup.push(
				{
					path: '/admin/users',
					label: 'Users',
					icon: 'person-group',
					iconPos: 'icon-left',
					subLinks: [
						{path: "/admin/user", label: "All Users"},
						...userLinks.map(link => ({path: link.path, label: link.label}))
					]
				}
			);
		}
		if (entityLinks.length > 0) {
			entityLinkGroup.push(
				{
					path: '/admin/entities',
					label: 'Entities',
					icon: 'list',
					iconPos: 'icon-left',
					subLinks: entityLinks.map(link => {
						return {
							path: link.path,
							label: link.label,
						}
					})
				}
			);
		}
		linkGroups.push(entityLinkGroup);

		// % protected region % [Add any new link groups here before other and bottom] off begin
		// % protected region % [Add any new link groups here before other and bottom] end

		const otherlinkGroup: ILink[] = [];
		// % protected region % [Update the link group for the timelines extension here] off begin
		otherlinkGroup.push(
			{
				path: '/admin/timelines',
				label: 'Timelines',
				icon: 'timeline',
				iconPos: 'icon-left',
				isDisabled: false
			}
		);
		// % protected region % [Update the link group for the timelines extension here] end

		// % protected region % [Add any additional links to otherLinkGroup here] off begin
		// % protected region % [Add any additional links to otherLinkGroup here] end

		if (otherlinkGroup.length > 0) {
			linkGroups.push(otherlinkGroup);
		}

		const bottomlinkGroup: ILink[] = [];
		bottomlinkGroup.push(
			// % protected region % [Modify the utility link group here] off begin
			{
				path: '/admin/',
				label: 'Utility',
				icon: 'file',
				iconPos: 'icon-left',
				subLinks: [
					{
						path: '/admin/styleguide',
						label: 'Style Guide',
						useATag: false
					},
					{
						path: '/admin/graphiql',
						label: 'GraphiQL',
						useATag: true,
					},
					{
						path: '/api/hangfire',
						label: 'Hangfire',
						useATag: true,
					},
					{
						path: '/api/swagger',
						label: 'OpenAPI',
						useATag: true,
					},
					{
						path: 'https://gitlab.codebots.dev',
						label: 'Git',
						useATag: true,
					},
				],
			}
			// % protected region % [Modify the utility link group here] end
		);

		// % protected region % [Update the logout link here] off begin
		bottomlinkGroup.push(
			{
				path: '/logout',
				label: 'Logout',
				icon: 'room',
				iconPos: 'icon-left'
			}
		);
		// % protected region % [Update the logout link here] end

		// % protected region % [Add any additional links to bottomlinkGroup here] off begin
		// % protected region % [Add any additional links to bottomlinkGroup here] end

		linkGroups.push(bottomlinkGroup);

		// % protected region % [Modify your link groups here before returning] off begin
		// % protected region % [Modify your link groups here before returning] end

		return linkGroups;
	}

	// % protected region % [Add custom methods here] off begin
	// % protected region % [Add custom methods here] end
}