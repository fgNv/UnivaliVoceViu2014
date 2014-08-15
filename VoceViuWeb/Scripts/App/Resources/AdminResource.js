app.factory("AdminResource", function ($resource) {
    return $resource("/api/posts/:id", {}, {
        query: { method: "GET", isArray: false }
    });
});