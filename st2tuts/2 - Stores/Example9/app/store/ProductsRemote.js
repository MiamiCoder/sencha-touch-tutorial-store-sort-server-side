Ext.define('App.store.ProductsRemote', {
    extend: 'Ext.data.Store',
    config: {
        model: 'App.model.Product',
        autoSync: false,
        proxy: {
            type: 'ajax',
            api: {
                read: '../../services/collectibles.ashx'
            },
            reader: {
                rootProperty:'products'
            }
        },
        sorters: [{
            property: 'productCode',
            direction: 'ASC'
        }],
        remoteSort:true
    }
});