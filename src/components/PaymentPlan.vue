<template>
<div class="tabletest">
    <mdb-tbl>
      <mdb-tbl-head>
        <tr>
          <th>Term</th>
          <th>Amount</th>
          <th>Installment</th>
          <th>Interest</th>
        </tr>
      </mdb-tbl-head>
      <mdb-tbl-body class="tblBody">
        <tr v-for="item in paymentPlan" :key="item.id">
          <th>{{item.id}}</th>
          <td>{{item.amount}}</td>
          <td>{{item.installment}}</td>
          <td>{{item.interest}}</td>
        </tr>
      </mdb-tbl-body>
    </mdb-tbl>
</div>
</template>

<script>
  import { mdbTbl, mdbTblHead, mdbTblBody } from 'mdbvue';
  export default {
    name: 'TablePage',
    components: {
      mdbTbl,
      mdbTblHead,
      mdbTblBody
    },
    computed: {
        paymentPlan () {
            return this.$store.state.paymentPlan
        }
    }
  }
</script>

<style scoped>
.tabletest{
    max-height: 100%;
}
</style>