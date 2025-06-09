import { createRouter, createWebHistory } from 'vue-router'
import AltaGastoView from '../views/AltaGastoView.vue'
import ListadoGastosView from '../views/ListadoGastosView.vue'

const routes = [
  { path: '/', component: ListadoGastosView },
  { path: '/nuevo', component: AltaGastoView }
]

export default createRouter({
  history: createWebHistory(),
  routes
})
