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
        "domain/BlogPost/BlogPostBroker",
        "domain/BlogPost/BlogPostFilterImpl",
        "domain/BlogPost/BlogPostSortImpl",
        "domain/BlogPost/BlogPostImpl",
        "core/authentication/securityContext",
        'domain/BlogCategory/BlogCategoryBroker'
    ],
    function PostsPaginatedViewModel($, config, i18n, stringUtils,
                        findRequestImpl, pageImpl, pagerImpl, pageRequestImpl, validationUtils,
                        app, alerts, shell, BlogPostBroker, BlogPostFilterImpl, BlogPostSortImpl, BlogPostImpl, securityContext, BlogCategoryBroker) {
        var viewModel = {},
            PAGE_SIZE = config.PAGE_SIZE,
            PAGE_SIZES = config.PAGE_SIZES,
            nextFilter = ko.observable(BlogPostFilterImpl()),
            currentFilter = BlogPostFilterImpl(),
            currentSort = ko.observable(BlogPostSortImpl()),
            currentPage = ko.observable(pageImpl()),
            currentPager = ko.observable(pagerImpl()),
            currentPageSize = ko.observable(PAGE_SIZE),

            categoryArray = ko.observableArray([]),

            activeOptions = [{ id: 0, name: i18n.t('NO') },
                           { id: 1, name: i18n.t('YES') }];

        // lifecycle definition
        function activate(id,title) {
            
            nextFilter(BlogPostFilterImpl());
            currentFilter = $.extend(true, {}, nextFilter());

            currentFilter.id = id;
            currentFilter.title = title;
            return $.when(loadCurrentPage());
        }

        // behaviour definition
        function loadCurrentPage() {
            loadCategories();
            return loadPageByIndex(currentPage().number, currentPage().totalPages);
        }

        function loadCategories() {
            debugger;
            BlogCategoryBroker.getAll().done(function(data) {
                categoryArray(data);
            });
        }

        function loadPageByIndex(index, totalElements) {
            if (index === 0 || index > 0 && index < currentPage().totalPages) {

                return BlogPostBroker.getAllPaginatedByIdTitle(
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
            //currentFilter = $.extend(true, {}, nextFilter());
            return loadFirstPage();
        }

        function clearFilter() {
            nextFilter(BlogPostFilterImpl());

            $('#active-both').click();

            return search();
        }

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
        viewModel.BlogPostImpl = BlogPostImpl;

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