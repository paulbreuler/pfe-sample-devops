import { Cache } from '../Cache/index'

export namespace Security {
    type UserRole = { roleid: string, name: string }
    type UserTeam = { teamid: string, name: string }

    export async function getUserRoles(): Promise<Array<UserRole>> {
        const cacheKey = "UserRoles";

        let userRoles = Cache.get(cacheKey);
        if (userRoles !== null) {
            return userRoles;
        }

        let context = Xrm.Utility.getGlobalContext();

        let roleIds = context.getUserRoles();
        let filters = roleIds.map(roleId => "(roleid eq " + roleId + ")");

        let options = "?$select=name&$filter=" + filters.join("or");

        let result = await Xrm.WebApi.retrieveMultipleRecords("roles", options);

        Cache.set(cacheKey, result.entities);
        return result.entities;
    }

    export async function userHasRole(roleName: string): Promise<boolean> {
        let userRoles = await getUserRoles();
        return userRoles.some(x => x.name == roleName);
    }

    export async function getUserTeams(): Promise<Array<UserTeam>> {
        const cacheKey = "UserRolesTeams";

        let userTeams = Cache.get(cacheKey);
        if (userTeams !== null) {
            return userTeams;
        }

        let context = Xrm.Utility.getGlobalContext();

        let userId = context.getUserId();

        let options = "?$select=name&$expand=teammembership_association($filter=systemuserid eq " + userId + ")";

        let result = await Xrm.WebApi.retrieveMultipleRecords("teams", options);

        Cache.set(cacheKey, result.entities);
        return result.entities;
    }

    export async function userHasTeam(teamName: string): Promise<boolean> {
        let userTeams = await getUserTeams();
        return userTeams.some(x => x.name == teamName);
    }
}