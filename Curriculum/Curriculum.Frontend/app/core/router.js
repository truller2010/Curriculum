/* global define: false, location: false */
define([
    "plugins/router", "core/util/urlUtils"
], function routerDecorator(router, urlUtils) {
    // TODO qunit routerDecorator

    "use strict";
    var TEST = "test";

    function reloadCurrentLocation() {
        return location.reload();
    }

    function navigateToIndex() {
        router.navigate("");
        return location.reload();
    }

    function navigateToRoot() {
        router.navigate("");
    }

    function navigateToTest() {
        return router.navigate(TEST);
    }

    function navigateToDetalleUsuario(idUsuario) {
        return router.navigate(urlUtils.joinPath("Usuario", idUsuario));
    }

    function navigateToListadoLaboratorios(idLab) {
        return router.navigate(urlUtils.joinPath("BuscadorLaboratorios"));
    }

    function navigateToDetalleLaboratorio(idLab) {
        return router.navigate(urlUtils.joinPath("Laboratorio", idLab));
    }

    function navigateToModalidadDePago() {
        return router.navigate(urlUtils.joinPath("RegistrarModalidadesPago"));
    }

    function navigateToRecibosPendientesDePago() {
        return router.navigate(urlUtils.joinPath("CYDRecibosPendientesPago"));
    }

    function navigateToVolumenesPendientesHistorico() {
        return router.navigate(urlUtils.joinPath("VolumenesPendientesHistorico"));
    }

    function navigateToRetribucionesEconomicas() {
        return router.navigate("#retribuciones-economicas");
    }

    router.reloadCurrentLocation = reloadCurrentLocation;
    router.navigateToIndex = navigateToIndex;
    router.navigateToRecibosPendientesDePago = navigateToRecibosPendientesDePago;
    router.navigateToDetalleUsuario = navigateToDetalleUsuario;
    router.navigateToListadoLaboratorios = navigateToListadoLaboratorios;
    router.navigateToDetalleLaboratorio = navigateToDetalleLaboratorio;
    router.navigateToRoot = navigateToRoot;
    router.navigateToModalidadDePago = navigateToModalidadDePago;
    router.navigateToTest = navigateToTest;
    router.navigateToRetribucionesEconomicas = navigateToRetribucionesEconomicas;

    return router;
});