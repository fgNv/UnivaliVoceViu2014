app.factory("DashboardResource", function ($resource) {
    return $resource("/api/dashboard/:action/:id", {}, {
        getAdvertiserData: {
            method: "GET",
            isArray: false,
            params: { 'action': 'GetAdvertiserData' }
        },
        getAdministratorData: {
            method: "GET",
            isArray: false,
            params: { 'action': 'GetAdministratorData' }
        }
    });
});