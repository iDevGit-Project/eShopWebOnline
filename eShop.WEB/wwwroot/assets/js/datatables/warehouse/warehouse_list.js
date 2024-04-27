// Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
var handleSearchDatatable = () => {
    const filterSearch = document.querySelector('[data-kt-warehouse-table-filter="search"]');
    filterSearch.addEventListener('keyup', function (e) {
        datatable.search(e.target.value).draw();
    });
}