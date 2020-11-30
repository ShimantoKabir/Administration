<template>
  <div class="my-template">
    <CCard>
      <CCardHeader>
        <i class="fas fa-bars"></i><strong> Manage</strong>
        <div class="card-header-actions">
          <CLink
            class="card-header-action btn-minimize"
            @click="isCollapsed = !isCollapsed"
          >
            <i v-if="isCollapsed" class="fas fa-angle-up"></i>
            <i v-else class="fas fa-angle-down"></i>
            &nbsp;
            <i class="fas fa-info-circle"></i>
          </CLink>
        </div>
      </CCardHeader>
      <CCollapse :show="isCollapsed" :duration="400">
        <CRow>
          <CCol col="12">
            <div class="my-card">
              <CCardBody>
                <tree
                  ref="tree"
                  :data="treeData"
                  @node:selected="onNodeSelect"
                  :options="treeOptions"
                >
                  <div slot-scope="{ node }" class="node-container">
                    <div class="node-text">{{ node.text }}</div>
                    <div class="node-controls" v-if="node.data.isSelected">
                      <CButtonGroup size="sm">
                        <CButton color="success" @click="onPopUpOpen(node,'a')"
                          ><i class="fas fa-plus"></i
                        ></CButton>
                        <CButton color="danger" @click="onPopUpOpen(node,'r')"
                          ><i class="fas fa-minus"></i
                        ></CButton>
                        <CButton color="info" @click="onPopUpOpen(node,'e')"
                          ><i class="fas fa-edit"></i
                        ></CButton>
                      </CButtonGroup>
                    </div>
                  </div>
                </tree>
              </CCardBody>
            </div>
          </CCol>
        </CRow>
      </CCollapse>
    </CCard>
    <c-modal
      :show.sync="isPopUpOpen"
      :close-on-backdrop="false"
      size="sm"
      color="dark"
    >
      <label>Name</label>
      <input type="text" class="form-control" v-model="menu.menuName" />
      <div v-if="!menu.menuName && isInvlid" class="ivf">
        Please input menu name.
      </div>

      <label class="ml">Tooltip</label>
      <input type="text" class="form-control" v-model="menu.tooltip" />

      <label class="ml">Power</label>
      <input type="number" class="form-control" v-model="menu.power" />
      <div v-if="menu.power === 0 && isInvlid" class="ivf">
        Please input menu power.
      </div>

      <label class="ml">Path</label>
      <input type="text" class="form-control" v-model="menu.path" />
      <div v-if="!menu.path && isInvlid" class="ivf">
        Please input menu path.
      </div>

      <label class="ml">Component</label>
      <input type="text" class="form-control" v-model="menu.component" />
      <div v-if="!menu.component && isInvlid" class="ivf">
        Please input menu component.
      </div>

      <template #header>
        <h5 class="modal-title">
          <b>Menu</b>
        </h5>
      </template>
      <template #footer>
        <c-button v-if="menu.id === 0" v-on:click="verifyInput('create')" color="success">
          Save
        </c-button>
        <c-button v-else v-on:click="verifyInput('update')" color="success">
          Update
        </c-button>
        <c-button v-on:click="onPopUpClose" color="danger">Close</c-button>
      </template>
    </c-modal>
    <alert ref="alert"></alert>
  </div>
</template>

<script>
import LiquorTree from "liquor-tree";
import VueMultiselect from "vue-multiselect";
import { freeSet } from "@coreui/icons";
import Alert from "@/component/Alert";
import HttpHandler from "../../utility/HttpHandler";

export default {
  name: "Menu",
  icons: { freeSet },
  components: {
    Alert,
    [LiquorTree.name]: LiquorTree,
    VueMultiselect,
  },
  mounted() {},
  data() {
    return {
      url: this.$store.state.baseUrl,
      isPopUpOpen: false,
      selectedNode: null,
      node: "",
      isInvlid: false,
      treeData: [
        {
          text: "Root",
          data: {
            isSelected: true,
            id: 1,
            parentId: 0,
            menuName: "Root",
            power: 0,
            tooltip: "Root",
            path: "",
            component: "",
            projectId: 1,
          },
          state: {
            expanded: true,
          },
          children: []
        }
      ],
      isCollapsed: true,
      treeOptions: {
        checkbox: false,
        deletion(node) {
          return node.checked();
        },
      },
      projects: [],
      menu: {
        id: 0,
        menuName: "",
        tooltip: "",
        path: "",
        component: "",
        power: 0,
        projectId: 0,
        project: null,
      },
    };
  },
  methods: {
    verifyInput(which){
      if(which === "create"){
        let x = this.isMenuInputVerified();
        if(x){
          this.onCreate();
        }
      }
    },
    isMenuInputVerified() {
      let isVerified = true;
      if (!this.menu.menuName) {
        this.$refs.alert.show({
          title: "Alert",
          bodyIcon: "fas fa-exclamation-circle",
          bodyMsg: "Please give a menu name.",
          code: 404,
          confirm: true,
        });
        this.isInvlid = true;
        isVerified = false;
      } else if (this.menu.power === 0) {
        this.$refs.alert.show({
          title: "Alert",
          bodyIcon: "fas fa-exclamation-circle",
          bodyMsg: "Please give a power of this menu.",
          code: 404,
          confirm: true,
        });
        this.isInvlid = true;
        isVerified = false;
      } else if (!this.menu.path) {
        this.$refs.alert.show({
          title: "Alert",
          bodyIcon: "fas fa-exclamation-circle",
          bodyMsg: "Please give a path of this menu.",
          code: 404,
          confirm: true,
        });
        this.isInvlid = true;
        isVerified = false;
      } else if (!this.menu.component) {
        this.$refs.alert.show({
          title: "Alert",
          bodyIcon: "fas fa-exclamation-circle",
          bodyMsg: "Please give a component name.",
          code: 404,
          confirm: true,
        });
        this.isInvlid = true;
        isVerified = false;
      } else {
        this.isInvlid = false;
        isVerified = true;
      }
      return isVerified;
    },
    onNodeSelect(n) {
      let selectedNode = this.$refs.tree.findAll({
        data: { isSelected: true },
      });
      selectedNode[0].data.isSelected = false;
      n.data.isSelected = true;
      this.selectedNode = n;
    },
    onCreate() {
      
      this.menu.power = Number(this.menu.power);
      console.log(JSON.stringify(this.menu));
      this.addNode(this.menu);

      // HttpHandler.handlePost(
      //   this.onCreate,
      //   this.$refs.alert,
      //   this.url + "menus",
      //   {
      //     menu: this.menu,
      //   }
      // ).then((res) => {
      //   console.log(JSON.stringify(res));
      //   if (res.data.code === 200) {
      //     this.$refs.alert.show({
      //       title: "Alert",
      //       bodyIcon: "fas fa-exclamation-circle",
      //       bodyMsg: res.data.msg,
      //       code: res.data.code,
      //       ok: true,
      //     });
      //   } else {
      //     this.$refs.alert.show({
      //       title: "Alert",
      //       bodyIcon: "fas fa-exclamation-circle",
      //       bodyMsg: res.data.msg,
      //       code: 404,
      //       try: true,
      //       onCallBack: this.onCreate,
      //     });
      //   }
      // });

    },
    addNode(menu) {
    
      this.selectedNode.append({
        text: menu.menuName,
        data: {
          id: menu.id,
          parentId: menu.parentId,
          menuName: menu.menuName,
          power: menu.power,
          tooltip: menu.tooltip,
          path: menu.path,
          component: menu.component,
          projectId: menu.projectId,
        },
        state: {
          selected: true,
          selectable: true,
          expanded: true,
        },
        children: [],
      });

      this.selectedNode = null;

    },
    onPopUpOpen(n,op){
      if(op === "a"){
        this.isPopUpOpen = true;
      } else if(op === "e"){
        this.menu.id = n.data.id;
        this.menu.menuName = n.data.menuName;
        this.menu.tooltip = n.data.tooltip;
        this.menu.path = n.data.path;
        this.menu.component = n.data.component;
        this.menu.power = n.data.power;
        this.menu.projectId = n.data.projectId;
        this.menu.project  = n.data.project;
        this.isPopUpOpen = true;
      } else{
        alert("Are you sure want to delete!");
      }
    },
    onPopUpClose(){
      this.isPopUpOpen = false;
      this.selectedNode = null;
      this.resetMenu();
    },
    resetMenu(){

        this.menu.id = 0;
        this.menu.menuName = "";
        this.menu.tooltip = "";
        this.menu.path = "";
        this.menu.component = "";
        this.menu.power = 0;
        this.menu.projectId = 0;

    }
  },
};
</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style scoped>
.node-container {
  display: flex;
  justify-content: space-between;
  width: 100%;
  height: 100%;
  align-items: baseline;
}
.my-model {
  position: fixed;
  z-index: 1999;
  left: 0;
  top: 0;
  width: 50%;
  height: 50%;
  overflow: auto;
  background-color: rgba(0, 0, 0, 0.4);
}
</style>