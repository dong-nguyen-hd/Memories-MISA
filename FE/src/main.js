import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import VTooltip from 'v-tooltip'

Vue.use(VTooltip, { defaultHtml: false })
Vue.config.productionTip = false

import LeftSideBar from "./components/layout/LeftSideBar";
import FeeHeader from "./components/header/FeeHeader";
import FeeContent from "./components/layout/FeeContent";
import FeeFooter from "./components/footer/FeeFooter";
import FeeFormInput from "./components/layout/FeeFormInput";
import FeeList from "./components/layout/FeeList";
import Loading from "./components/layout/Loading";

Vue.component("left-side-bar", LeftSideBar)
Vue.component("Header", FeeHeader)
Vue.component("Content", FeeContent)
Vue.component("Footer", FeeFooter)
Vue.component("form-input", FeeFormInput)
Vue.component("fee-list", FeeList)
Vue.component("Loading", Loading)

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')