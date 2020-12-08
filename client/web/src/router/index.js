import { createRouter, createWebHashHistory } from 'vue-router'
import MainContainer from '../components/MainContainer.vue'

const routes = [
  {
    path: '/',
    name: 'MainContainer',
    component: MainContainer
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
