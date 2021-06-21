import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        baseURI: "https://localhost:5001/",
        apiFee: {
            getPagination: "api/v1/fee/pagination",
            bodyPagination: {
                page: 1,
                pageSize: 10,
                feeName: null,
                feeGroupId: null,
                feeRangeId: null,
                turnFeeId: null,
                amountOfFee: null,
                follow: false
            },
            responsePagination: {
                page: null,
                pageSize: null,
                firstPage: null,
                lastPage: null,
                totalPages: null,
                totalRecords: null,
                nextPage: null,
                previousPage: null,
            },
            insert: "api/v1/fee",
            update: "api/v1/Fee/",
            delete: "api/v1/Fee",
            deleteAll: "api/v1/fee/delete"
        },
        apiFeeGroup: {
            list: "api/v1/FeeGroup",
            insert: "",
            update: "",
            delete: "",
            feeGroupList: []
        },
        apiFeeRange: {
            list: "api/v1/FeeRange",
            insert: "",
            update: "",
            delete: "",
            feeRangeList: []
        },
        apiUnitFee: {
            list: "api/v1/UnitFee",
            insert: "",
            update: "",
            delete: "",
            unitFeeList: []
        },
        apiTurnFee: {
            list: "api/v1/TurnFee",
            turnFeeList: []
        },
        apiQuality: {
            list: "api/v1/Quality",
            qualityList: []
        },
    },
    getters: {
        getPaginationFee: state => {
            return `${state.baseURI}${state.apiFee.getPagination}`
        },
        getInsertFee: state => {
            return `${state.baseURI}${state.apiFee.insert}`
        },
        getDeleteFee: state => {
            return `${state.baseURI}${state.apiFee.delete}`
        },
        getDeleteAllFee: state => {
            return `${state.baseURI}${state.apiFee.deleteAll}`
        },
        getFeeGroup: state => {
            return `${state.baseURI}${state.apiFeeGroup.list}`
        },
        getFeeRange: state => {
            return `${state.baseURI}${state.apiFeeRange.list}`
        },
        getUnitFee: state => {
            return `${state.baseURI}${state.apiUnitFee.list}`
        },
        getTurnFee: state => {
            return `${state.baseURI}${state.apiTurnFee.list}`
        },
        getQuality: state => {
            return `${state.baseURI}${state.apiQuality.list}`
        },
    },
    mutations: {
        getFeePagination(state, payload) {
            state.apiFee.responsePagination.firstPage = payload.firstPage;
            state.apiFee.responsePagination.lastPage = payload.lastPage;
            state.apiFee.responsePagination.totalPages = payload.totalPages;
            state.apiFee.responsePagination.totalRecords = payload.totalRecords;
            state.apiFee.responsePagination.nextPage = payload.nextPage;
            state.apiFee.responsePagination.previousPage = payload.previousPage;
            state.apiFee.responsePagination.page = payload.page;
            state.apiFee.responsePagination.pageSize = payload.pageSize;
        },
        resetBodyFeePagination(state, payload) {
            state.apiFee.bodyPagination.page = payload.page;
            state.apiFee.bodyPagination.pageSize = payload.pageSize;
            state.apiFee.bodyPagination.feeName = payload.feeName;
            state.apiFee.bodyPagination.feeGroupId = payload.feeGroupId;
            state.apiFee.bodyPagination.feeRangeId = payload.feeRangeId;
            state.apiFee.bodyPagination.turnFeeId = payload.turnFeeId;
            state.apiFee.bodyPagination.amountOfFee = payload.amountOfFee;
            state.apiFee.bodyPagination.follow = payload.follow;
        },
        changePageSize(state, payload) {
            state.apiFee.bodyPagination.pageSize = payload;
        },
        changePage(state, payload) {
            state.apiFee.bodyPagination.page = payload;
        },
        changeFeeFollow(state, payload) {
            state.apiFee.bodyPagination.follow = payload;
        },
        changeFeeNameSearch(state, payload) {
            state.apiFee.bodyPagination.feeName = payload ? payload : null;
        },
        changeFeeAmountSearch(state, payload) {
            state.apiFee.bodyPagination.amountOfFee = payload ? payload : null;
        },
        changeTurnFeeSearch(state, payload) {
            state.apiFee.bodyPagination.turnFeeId = payload;
        },
        changeFeeGroupSearch(state, payload) {
            state.apiFee.bodyPagination.feeGroupId = payload ? payload : null;
        },
        changeFeeRangeSearch(state, payload) {
            state.apiFee.bodyPagination.feeRangeId = payload ? payload : null;
        },
        changeFeeRangeList(state, payload) {
            state.apiFeeRange.feeRangeList = payload;
        },
        changeFeeGroupList(state, payload) {
            state.apiFeeGroup.feeGroupList = payload;
        },
        changeUnitFeeList(state, payload) {
            state.apiUnitFee.unitFeeList = payload;
        },
        changeTurnFeeList(state, payload) {
            state.apiTurnFee.turnFeeList = payload;
        },
        changeQualityList(state, payload) {
            state.apiQuality.qualityList = payload;
        },
    }
});