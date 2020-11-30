<template>
  <div class="side-nav" >
    <div class="logo-area" >
      <img src="../assets/img/logo.png" alt="logo">
      <h4>Administration</h4>
    </div>
    <div class="menu-area" >

    </div>
  </div>
</template>

<script>
export default {
  name: "SideNav"
}
</script>

<style scoped>
  .side-nav{
    flex: 2;
    height: 100%;
    border-right: 1px solid lightgray;
  }
  .logo-area{
    display: flex;
    padding: 10px;
    align-items: center;
    justify-content: center;
    background-color: lightgray;
  }
  .logo-area > img{
    width: 30px;
    height: 30px;
  }
  .logo-area > h4{
    margin-left: 10px;
  }
</style>