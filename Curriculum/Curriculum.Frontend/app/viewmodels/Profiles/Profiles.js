/* global _: false, define: false, ko: false */
define(
    [
        "jquery",
        "core/config",
        "core/i18n",
        "core/util/stringUtils",
        "core/crud/findRequestImpl",
        "core/crud/pageImpl",
        "core/crud/pagerImpl",
        "core/crud/pageRequestImpl",
        "core/util/validationUtils",
        "durandal/app",
        "viewmodels/alerts",
        "viewmodels/shell",
        "domain/Profiles/ProfilesBroker",
        "domain/Profiles/ProfilesFilterImpl",
        "domain/Profiles/ProfilesSortImpl",
        "domain/Profiles/ProfilesImpl",
        'domain/Profiles/ProfilesBroker'
    ],
    function PostsPaginatedViewModel($, config, i18n, stringUtils,
                        findRequestImpl, pageImpl, pagerImpl, pageRequestImpl, validationUtils,
                        app, alerts, shell, ProfilesBroker, ProfilesFilterImpl, ProfilesSortImpl, ProfilesImpl, ProfilesBroker) {


        var viewModel = {},
            PAGE_SIZE = config.PAGE_SIZE,
            PAGE_SIZES = config.PAGE_SIZES,
            nextFilter = ko.observable(ProfilesFilterImpl()),
            currentFilter = ProfilesFilterImpl(),
            currentSort = ko.observable(ProfilesSortImpl()),
            currentPage = ko.observable(pageImpl()),
            currentPager = ko.observable(pagerImpl()),
            currentPageSize = ko.observable(PAGE_SIZE),
            tagArray = ko.observableArray([]),
            categoryArray = ko.observableArray([]),
            archivesArray = ko.observableArray([]),

            activeOptions = [{ id: 0, name: i18n.t('NO') },
                           { id: 1, name: i18n.t('YES') }];



        // lifecycle definition
        function activate() {

            nextFilter(ProfilesFilterImpl());
            currentFilter = $.extend(true, {}, nextFilter());
            return $.when(loadCurrentPage());

        }

        function loadCurrentPage() {
            return loadPageByIndex(currentPage().number, currentPage().totalPages);
        }

        function loadPageByIndex(index, totalElements) {
            if (index === 0 || index > 0 && index < currentPage().totalPages) {

                return ProfilesBroker.getAllPaginated(
                    findRequestImpl(currentFilter, pageRequestImpl(index, currentPageSize,
                        currentSort, totalElements))).done(refreshCurrentPage);
            }
        }

        function refreshCurrentPage(data) {

            currentPage(pageImpl(data));
            currentPager(pagerImpl(data));
        }

        function loadFirstPage() {
            return loadPageByIndex(0);
        }

        function loadLastPage() {
            return loadPageByIndex(currentPage().totalPages - 1);
        }

        function sortByProperty(property) {
            currentSort().setFirstOrderByProperty(property);
            currentSort().getOrderByIndex(0).cycleOrder();

            return loadCurrentPage();
        }

        function search() {
            // deep copy next filter
            currentFilter = $.extend(true, {}, nextFilter());
            return loadFirstPage();
        }

        function clearFilter() {
            nextFilter(ProfilesFilterImpl());

            $('#active-both').click();

            return search();
        }

        //isLoading: ko.computed(function () {
        //    return brokerUtils.requestCount > 0 || router.isNavigating();
        //});


        //viewModel.isLoading = isLoading;
        viewModel.archivesArray = archivesArray;
        viewModel.categoryArray = categoryArray;
        viewModel.tagArray = tagArray;
        // state revelation
        viewModel.i18n = i18n;
        viewModel.shell = shell;
        viewModel.validationUtils = validationUtils;
        viewModel.nextFilter = nextFilter;
        viewModel.currentSort = currentSort;
        viewModel.currentPage = currentPage;
        viewModel.currentPager = currentPager;
        viewModel.currentPageSize = currentPageSize;
        viewModel.availablePageSizes = PAGE_SIZES;
        viewModel.activeOptions = activeOptions;
        viewModel.ProfilesImpl = ProfilesImpl;

        // lifecycle revelation
        viewModel.activate = activate;

        // behaviour revelation
        viewModel.refreshCurrentPage = refreshCurrentPage;
        viewModel.loadPageByIndex = loadPageByIndex;
        viewModel.loadFirstPage = loadFirstPage;
        viewModel.loadCurrentPage = loadCurrentPage;
        viewModel.loadLastPage = loadLastPage;
        viewModel.search = search;
        viewModel.clearFilter = clearFilter;



        return viewModel;
    });