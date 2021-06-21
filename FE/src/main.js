import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import VTooltip from 'v-tooltip'

Vue.use(VTooltip, { defaultHtml: false })
Vue.config.productionTip = false

import LeftSideBar from "./components/LeftSideBar";
import Header from "./components/Header";
import Content from "./components/Content";
import Footer from "./components/Footer";
import FormInput from "./components/FormInput";
import FeeList from "./components/FeeList";
import Loading from "./components/Loading";

Vue.component("left-side-bar", LeftSideBar)
Vue.component("Header", Header)
Vue.component("Content", Content)
Vue.component("Footer", Footer)
Vue.component("form-input", FormInput)
Vue.component("fee-list", FeeList)
Vue.component("Loading", Loading)

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')