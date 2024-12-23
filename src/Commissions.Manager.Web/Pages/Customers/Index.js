$(function () {
    var l = abp.localization.getResource('Manager');
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Customers/CreateModal',
        modalClass: 'createCustomer'
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Customers/EditModal',
        modalClass: 'editCustomer'
    });

    var dataTable = $('#CustomersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                commissions.manager.customers.customer.getList,
                function (requestData) {
                    return {
                        skipCount: requestData.start,
                        maxResultCount: requestData.length,
                        sorting: requestData.columns[requestData.order[0].column].data + " " + requestData.order[0].dir
                    };
                }
            ),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: true,
                                    action: function (data) {
                                        editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: true,
                                    confirmMessage: function (data) {
                                        return l('CustomerDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        commissions.manager.customers.customer
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.success(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            })
                                            .catch(function (error) {
                                                abp.notify.error(error.message || l('ErrorDeletingRecord'));
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Email'),
                    data: "email",
                },
                {
                    title: l('Commissions'),
                    data: "commissionNames",
                    render: function (data) {
                        return data && data.length > 0 ? data.join(', ') : l('NoCommissions');
                    }
                }
            ]
        })
    );

    // Handle Create button click
    $('#NewCustomerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    // Handle successful creation
    createModal.onResult(function () {
        abp.notify.success(l('SuccessfullyCreated'));
        dataTable.ajax.reload();
    });

    // Handle successful edit
    editModal.onResult(function () {
        abp.notify.success(l('SuccessfullyUpdated'));
        dataTable.ajax.reload();
    });

    // Error handling for modals
    createModal.onError(function (error) {
        abp.notify.error(error.message || l('ErrorCreatingRecord'));
    });

    editModal.onError(function (error) {
        abp.notify.error(error.message || l('ErrorUpdatingRecord'));
    });
});