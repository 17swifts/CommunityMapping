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
import { ILink } from 'Views/Components/Navigation/Navigation';
import { RouteComponentProps } from 'react-router';
import { store } from 'Models/Store';
// % protected region % [Add any extra imports here] on begin
import Logo from "../../../assets/img/logo_favicon-3.png"
// % protected region % [Add any extra imports here] end

export function getFrontendNavLinks(pageProps: RouteComponentProps): ILink[][] {
	// % protected region % [Add any logic before displaying page links here] off begin
	// % protected region % [Add any logic before displaying page links here] end
	return [
		[
			// % protected region % [Customise top nav section here] on begin
			//{label: "Home", path: '/', icon: "home", iconPos: 'icon-left'},
			{label: "Profile", path: '/myprofile', icon: "person", iconPos: 'icon-left', subLinks: [{label: "My Details", path: '/myprofile', icon: "person", iconPos: 'icon-left'}, {label: "My Services", path: '/myservices', icon: "actions", iconPos: 'icon-left'}]},			
			// % protected region % [Customise top nav section here] end
		],
		[
			// % protected region % [Customise middle nav section here] on begin
			{label: "My Community Mapping", path: '/mycommunitymapping', icon: "home", iconPos: 'icon-left'},
			{label: "Service Profile", path: '/serviceprofile', icon: "roadmap", iconPos: 'icon-left', subLinks: [{label: "Service Profile", path: '/serviceprofile', icon: "raodmap", iconPos: 'icon-left'},{label: "Service  Dashboard", path: '/servicedashboard', icon: "chart-pie", iconPos: 'icon-left'},{label: "Services", path: '/allservices', icon: "actions", iconPos: 'icon-left'}]},
			{label: "Community Profile", path: '/communityprofile', icon: "map", iconPos: 'icon-left'},
			{label: "Funding", path: '/funding', icon: "money", iconPos: 'icon-left'},
			// % protected region % [Customise middle nav section here] end
		],
		[
			// % protected region % [Customise bottom nav section here] off begin
			{label: "Login", path: '/login', icon: "login", iconPos: 'icon-left', shouldDisplay: () => !store.loggedIn},
			{label: "Logout", path: '/logout', icon: "room", iconPos: 'icon-left', shouldDisplay: () => store.loggedIn}
			// % protected region % [Customise bottom nav section here] end
		],
	];
}
