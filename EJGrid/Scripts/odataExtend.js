var ODataV4Adaptor = new ej.ODataAdaptor().extend({
    options: {
        count: "$count",
        search: "$search"
    },
    onCount: function (e) {
        return e === true ? "true" : "";
    },
    //beforeSend: function (dm, request, settings) {
    //    // some services do not support custom header on crossDomain (CORS) request
    //    if (!dm.dataSource.crossDomain) {
    //        request.setRequestHeader("DataServiceVersion", "4.0");
    //        request.setRequestHeader("MaxDataServiceVersion", "4.0");
    //    }
    //},
    processResponse: function (data, ds, query, xhr, request) {
        var count;
        if (query && query._requiresCount) {
            count = data['@odata.count'];
            data = data.value;
        }
        return ej.isNullOrUndefined(count) ? data : { result: data, count: count };
    },
    onEachSearch: function (e) {
        var search = this.pvt.search || [];
        search.push(e.key);
        this.pvt.search = search;
    },
    onSearch: function (e) {
        return this.pvt.search.join(" OR ");
    }
});