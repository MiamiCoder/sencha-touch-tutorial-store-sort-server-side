/* 
Stores - server-side sorting.
*/

Ext.application({
    name: 'App',
    models: ['Product'],
    stores: ['ProductsRemote'], 
    launch: function () {

        // Use the getStore function to get a reference to a store added via the stores config.
        var productsStoreRemote = Ext.getStore('ProductsRemote');

        productsStoreRemote.on({
            load: this.onStoreRemoteLoad
        });        

        // You can use the sort method to sort the store
        productsStoreRemote.sort([
             {
                 property: 'productLine',
                 direction: 'ASC'
             },
            {
                property: 'productName',
                direction: 'ASC'
            }
        ]);

        productsStoreRemote.load();
    },

    onStoreRemoteLoad: function (store, records) {

        // Render records sorted by product code as defined in the sorters config of the store
        var msg = "Remote Records sorted by",
            sorters = store.getSorters();

        if (sorters) {
            for (var i = 0, j = sorters.length; i < j; i++) {            
                msg = msg + " " + sorters[i].get('property') + " " + sorters[i].get('direction');
            }
        }        

        console.log(msg);
        store.each(function (record) {
            console.log('- ' + record.get('productName'));
        });

    }
});      