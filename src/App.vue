<template>
  <mdb-container>
    <mdb-row>
      <mdb-col class="col">
        <LoanForm/>
      </mdb-col>
    <mdb-col class="col">
      <PaymentPlan/>
    </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
import LoanForm from './components/LoanForm.vue'
import PaymentPlan from './components/PaymentPlan.vue'
import { mdbContainer, mdbRow, mdbCol } from 'mdbvue';

export default {
  name: 'App',
  components: {
    LoanForm,
    PaymentPlan,
    mdbContainer,
    mdbRow,
    mdbCol
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
  align-items: center;
  justify-content: center;
}

html, body {
    height:100%;
}

.container {
  height: 100%;
  padding: 50px 0px 50px;
}

.row {
  height: 100%;
  align-items: center;
}

.col{
  max-height: 100%;
  overflow: auto;
}

</style>
