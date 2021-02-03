<template>
  <mdb-container>
  <form>
    <p class="h4 text-center mb-4">Calculate payment plan</p>
    <div class="grey-text">
      <mdb-input label="Amount (NOK)" icon="coins" type="number" :min="5000" :max="20000000" v-model="amount"/>
      <mdb-input label="Repayment period (years)" icon="hourglass" type="number" :min="1" :max="30" v-model="years"/>
    </div>
    <div class="text-center">
      <mdb-btn v-on:click="calculatePaymentPlan">Calculate</mdb-btn>
    </div>
  </form>
  </mdb-container> 
</template>

<script>
  import { mdbInput, mdbBtn, mdbContainer} from 'mdbvue';
  import Vue from 'vue';
  import axios from 'axios';
  import VueAxios from 'vue-axios';
  Vue.use(VueAxios, axios)
  export default {
    name: 'LoanForm',
    components: {
      mdbInput,
      mdbBtn,
      mdbContainer
    },
    data() {
      return {
        amount: 1000000,
        years: 20,
      };
    },
    methods: {
        calculatePaymentPlan() {
            this.axios
                .get('https://localhost:5002/api/LoanTypes/PaymentPlan/', {params: this.axiosParams})
                .then(response => (this.$store.dispatch('setPaymentPlan', response.data)))
                .catch(error => console.log(error))
        }
    },
    computed: {
        axiosParams() {
            const params = new URLSearchParams();
            params.append('type', 'housing');
            params.append('amount', this.amount);
            params.append('years', this.years);
            return params;
        }
    }
  }
</script>

<style scoped>


</style>