<template>
  <div class="form-wrapper">
    <div class="form-container">
      <h2>Registrar Gasto</h2>

      <form @submit.prevent="guardar">
        <!-- Monto -->
        <div class="form-group">
          <label>Monto</label>
          <input
            v-model.number="gasto.monto"
            type="number"
            required min="0.01" step="0.01"
            placeholder="Ej: 2500.00"
          />
        </div>

        <!-- Descripción -->
        <div class="form-group">
          <label>Descripción</label>
          <input
            v-model="gasto.descripcion"
            type="text"
            required minlength="3" maxlength="250"
            placeholder="Ej: Cena en restaurante"
          />
        </div>

        <!-- Fecha -->
        <div class="form-group">
          <label>Fecha</label>
          <input
            v-model="gasto.fecha"
            type="date"
            :max="hoy"
            required
          />
        </div>

        <!-- Comercio -->
        <div class="form-group">
          <label>Nombre del Comercio</label>
          <input
            v-model="gasto.nombreComercio"
            type="text"
            required maxlength="250"
            placeholder="Ej: Supermercado Día"
          />
        </div>

        <!-- Botón -->
        <div class="form-group">
          <button type="submit">Guardar Gasto</button>
        </div>
      </form>

      <transition name="fade">
        <div v-if="mensaje" class="mensaje" :class="mensaje.includes('éxito') ? 'exito' : 'error'">
          {{ mensaje }}
        </div>
      </transition>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      gasto: {
        monto: null,
        descripcion: '',
        fecha: '',
        nombreComercio: ''
      },
      mensaje: ''
    }
  },
  computed: {
    hoy() {
      return new Date().toISOString().split('T')[0];
    }
  },
  methods: {
    async guardar() {
      try {
        await axios.post('http://localhost:5210/api/Gastos/Create', this.gasto);
        this.mensaje = "✅ Gasto guardado con éxito";
        this.gasto = { monto: null, descripcion: '', fecha: '', nombreComercio: '' };
        setTimeout(() => this.mensaje = '', 3000);
      } catch (error) {
        this.mensaje = "❌ Error al guardar el gasto";
        setTimeout(() => this.mensaje = '', 3000);
      }
    }
  }
}
</script>

<style scoped>
/* Fondo */
.form-wrapper {
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: linear-gradient(135deg, #cce3ff, #f0f9ff);
  padding: 20px;
}

/* Tarjeta */
.form-container {
  background-color: white;
  border-radius: 20px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
  border: 1px solid #b3d4fc;
  padding: 40px;
  width: 100%;
  max-width: 500px;
}

.form-container h2 {
  text-align: center;
  color: #1d4ed8;
  margin-bottom: 30px;
  font-size: 28px;
}

/* Grupos de campos */
.form-group {
  margin-bottom: 20px;
}

.form-group label {
  display: block;
  font-weight: 600;
  margin-bottom: 8px;
  color: #374151;
}

.form-group input {
  width: 100%;
  padding: 12px 15px;
  border-radius: 10px;
  border: 1px solid #ccc;
  transition: border 0.3s ease;
  font-size: 16px;
}

.form-group input:focus {
  outline: none;
  border: 2px solid #2563eb;
  background-color: #f9fbff;
}

/* Botón */
button {
  width: 100%;
  background-color: #2563eb;
  color: white;
  font-weight: bold;
  padding: 12px;
  border: none;
  border-radius: 10px;
  cursor: pointer;
  transition: background-color 0.3s ease, box-shadow 0.3s;
}

button:hover {
  background-color: #1e40af;
  box-shadow: 0 4px 10px rgba(37, 99, 235, 0.4);
}

/* Mensaje */
.mensaje {
  margin-top: 20px;
  padding: 12px;
  border-radius: 8px;
  text-align: center;
  font-weight: 600;
  font-size: 15px;
}

.exito {
  background-color: #d1fae5;
  color: #065f46;
  border: 1px solid #10b981;
}

.error {
  background-color: #fee2e2;
  color: #991b1b;
  border: 1px solid #ef4444;
}

/* Fade transition */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s ease;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>
