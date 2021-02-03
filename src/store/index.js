import Vue from "vue";
import Vuex from "vuex";
 
Vue.use(Vuex);
 
export default new Vuex.Store({
 state: {
     paymentPlan: [
         {id: 1, amount: 123, installment: 100, interest: 23},
        {id: 2, amount: 345, installment: 300, interest: 45},
        {id: 3, amount: 567, installment: 500, interest: 67}
    ]
 },
 getters: {
 },
 mutations: {
     setPaymentPlan (state, plan){
         state.paymentPlan = plan;
     }

 },
 actions: {
     setPaymentPlan ({commit}, plan){
        commit('setPaymentPlan', plan)
     }
 }
});