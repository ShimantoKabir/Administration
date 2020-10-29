<template>
    <div class="my-template" >
        <CCard>
            <CCardHeader>
                <i class="fas fa-bars" ></i><strong> Manage</strong>
                <div class="card-header-actions">
                    <CLink class="card-header-action btn-minimize" @click="isCollapsed = !isCollapsed">
                        <i v-if="isCollapsed" class="fas fa-angle-up" ></i>
                        <i v-else class="fas fa-angle-down" ></i>
                        &nbsp;
                        <i class="fas fa-info-circle" ></i>
                    </CLink>
                </div>
            </CCardHeader>
            <CCollapse :show="isCollapsed" :duration="400">
                <CRow>
                    <CCol col="6">
                        <div class="my-card" >
                            <c-card-body>
                                <label>Menu Name</label>
                                <input type="text" class="form-control" v-model="menu.menuName" >
                                <div v-if="!menu.menuName" class="ivf" >Please input menu name.</div>

                                <label class="ml" >Tooltip</label>
                                <input type="text" class="form-control" v-model="menu.tooltip" >
                                <div v-if="!menu.tooltip" class="ivf" >Please input menu name.</div>

                                <label class="ml" >Power</label>
                                <input type="number" class="form-control" v-model="menu.power" >
                                <div v-if="menu.power === 0" class="ivf" >Please input menu power.</div>

                                <label class="ml" >Path</label>
                                <input type="text" class="form-control" v-model="menu.path" >
                                <div v-if="!menu.path" class="ivf" >Please input menu path.</div>

                                <label class="ml" >Component</label>
                                <input type="text" class="form-control" v-model="menu.component" >
                                <div v-if="!menu.component" class="ivf" >Please input menu component.</div>

                                <label>Project</label>
                                <vue-multiselect
                                    v-model="menu.project"
                                    :options="projects"
                                    :searchable="true"
                                    placeholder="Select one"
                                    label="projectName"
                                    track-by="id" >
                                </vue-multiselect>
                                <div v-if="menu.project === null" class="ivf" >Please input menu component.</div>
                            </c-card-body>
                            <c-card-footer>
                                <c-row class="justify-content-between" >
                                    <c-button color="primary" size="sm" v-on:click="onCreate" >Save</c-button>
                                    <c-button color="secondary" size="sm" >Reset</c-button>
                                </c-row>
                            </c-card-footer>
                        </div>
                    </CCol>
                    <CCol col="6">
                        <div class="my-card" >
                            <c-card-header v-if="selectedNode" >
                                <c-row class="justify-content-between" >
                                    <c-button v-on:click="addNode" color="success" size="sm" >
                                        <i class="fas fa-plus" ></i>
                                    </c-button>
                                    <c-button color="danger" size="sm" >
                                        <i class="fas fa-minus" ></i>
                                    </c-button>
                                </c-row>
                            </c-card-header>
                            <CCardBody>
                                <tree
                                    :data="treeData"
                                    @node:selected="onNodeSelect"
                                    :options="treeOptions" >
                                </tree>
                            </CCardBody>
                        </div>
                    </CCol>
                </CRow>
            </CCollapse>
        </CCard>
        <alert ref="alert" ></alert>
    </div>
</template>

<script>

import LiquorTree from 'liquor-tree'
import VueMultiselect from 'vue-multiselect'
import { freeSet } from '@coreui/icons'
import Alert from "@/component/Alert";

export default {
	name: "Menu",
	icons: { freeSet },
	components: {
        Alert,
		[LiquorTree.name]: LiquorTree,VueMultiselect
	},
    mounted() {

    },
    data() {
		return{
			selectedNode : '',
            node : '',
			treeData : [
				{
				  text: 'Administration',
                  data : {
				      srl : 0,
                      level : 0
                  },
				  state: {
				      expanded: true
                  },
				  children: []
				}
			],
			isCollapsed: true,
			treeOptions: {
				checkbox: false,
				deletion(node) {
				  return node.checked()
				}
			},
			projects: [
			    { id: 1, projectName: "Administration" },
			    { id: 2, projectName: 'Meal Management System' },
			    { id: 3, projectName: 'AIS' },
			    { id: 4, projectName: 'EchoDesk' }
			],
			menu: {
				id : 0,
				menuName : '',
				title: '',
				tooltip : '',
				path: '',
				component: '',
				power: 0,
				projectId : 0,
				project : null
			}
		}
	},
	methods : {
	    isMenuInputVerified(){
	        let isVerified = true;
            if (!this.menu.menuName){
                this.$refs.alert.show({
                    title : "Alert",
                    bodyIcon: "fas fa-exclamation-circle",
                    bodyMsg : "Please give a menu name.",
                    code: 404,
                    confirm : true,
                });
                isVerified = false;
            } else if (!this.menu.component){
                this.$refs.alert.show({
                    title : "Alert",
                    bodyIcon: "fas fa-exclamation-circle",
                    bodyMsg : "Please input .",
                    code: 404,
                    confirm : true,
                });
            }
        },
		onNodeSelect(n){
            this.isUpdateEnable = true;
            this.node = JSON.parse(JSON.stringify(n));
            this.selectedNode = n;
		},
		onCreate(){
			console.log(JSON.stringify(this.menu));
		},
        addNode(){
            this.selectedNode.append({
                text : this.menu.menuName,
                data : {
                    id : 0,
                    level : this.node.data.srl,
                    srl : this.node.data.level
                },
                state : {
                    selected : true,
                    selectable : true,
                    expanded : true
                },
                children : []
            });
        }
	}
}
</script>
<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style scoped>

</style>