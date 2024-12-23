$(function () {
    var l = abp.localization.getResource('Manager');
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Commissions/CreateModal',
        modalClass: 'createCommission'
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Commissions/EditModal',
        modalClass: 'editCommission'
    });

    var dataTable = $('#CommissionsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                commissions.manager.commissions.commission.getAllCommissionsWithCustomerNames
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
                                        return l('CommissionDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        commissions.manager.commissions.commission
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.success(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
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
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:CommissionType.' + data);
                    }
                },
                {
                    title: l('Total'),
                    data: "total",
                    render: function (data) {
                        return data.toFixed(2);
                    }
                },
                {
                    title: l('Customer'),
                    data: "customerName"
                },
                {
                    title: l('IsActive'),
                    data: "isActive",
                    render: function (data) {
                        return `<i class="fa fa-${data ? 'check' : 'times'}"></i>`;
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyCreated'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyUpdated'));
    });

    $('#NewCommissionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});