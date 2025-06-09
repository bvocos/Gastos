<template>
  <div class="min-h-screen bg-fondo flex items-center justify-center p-6">
    <div class="bg-white p-6 rounded-2xl shadow-xl w-full max-w-4xl border border-blue-300">
      <h2 class="text-2xl font-bold text-blue-800 mb-4 text-center">Listado de Gastos</h2>

      <div class="overflow-x-auto rounded-lg">
        <table class="tabla-gastos min-w-full divide-y divide-gray-200">
          <thead>
            <tr>
              <th>Fecha</th>
              <th>Descripción</th>
              <th>Monto</th>
              <th>Comercio</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="gasto in gastos" :key="gasto.id">
              <td>{{ formatearFecha(gasto.fecha) }}</td>
              <td>{{ gasto.descripcion }}</td>
              <td class="monto">${{ gasto.monto.toFixed(2) }}</td>
              <td>{{ gasto.nombreComercio }}</td>
            </tr>
            <tr v-if="gastos.length === 0">
              <td colspan="4" class="sin-datos">No hay gastos registrados.</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      gastos: []
    }
  },
  mounted() {
    axios.get('http://localhost:5210/api/Gastos/GetList')
      .then(res => this.gastos = res.data)
      .catch(() => alert("Error al cargar los gastos"));
  },
  methods: {
    formatearFecha(fechaIso) {
      const fecha = new Date(fechaIso)
      const dia = String(fecha.getDate()).padStart(2, '0')
      const mes = String(fecha.getMonth() + 1).padStart(2, '0')
      const anio = fecha.getFullYear()
      return `${dia}/${mes}/${anio}`
    }
  }
}
</script>

<style scoped>
.bg-fondo {
  background: linear-gradient(to bottom right, #dbeafe, #f0f9ff);
}

.tabla-gastos {
  border-collapse: collapse;
  width: 100%;
  font-family: 'Segoe UI', sans-serif;
}

.tabla-gastos thead {
  background-color: #2563eb;
  color: white;
}

.tabla-gastos th,
.tabla-gastos td {
  padding: 12px 16px;
  text-align: left;
  border-bottom: 1px solid #d1d5db;
}

.tabla-gastos tbody tr:nth-child(even) {
  background-color: #f3f4f6;
}

.tabla-gastos tbody tr:hover {
  background-color: #e0f2fe;
  transition: background-color 0.2s ease-in-out;
}

.tabla-gastos .monto {
  font-weight: bold;
  color: #047857;
}

.sin-datos {
  text-align: center;
  color: #6b7280;
  padding: 16px;
  font-style: italic;
}
</style>
