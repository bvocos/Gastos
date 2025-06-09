<template>
  <div class="app-wrapper">
    <h1>App de Gastos</h1>
    <nav>
      <router-link to="/" exact-active-class="active-link">Listado</router-link>
      <span>|</span>
      <router-link to="/nuevo" exact-active-class="active-link">Nuevo Gasto</router-link>
    </nav>

    <router-view />
  </div>
</template>

<style scoped>
.app-wrapper {
  min-height: 100vh;
  padding: 20px;
  background: linear-gradient(to bottom right, #e0f2fe, #f8fafc);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

/* Título */
h1 {
  text-align: center;
  font-size: 36px;
  font-weight: bold;
  color: #1e3a8a;
  margin-bottom: 30px;
}

/* Navegación */
nav {
  display: flex;
  justify-content: center;
  gap: 20px;
  margin-bottom: 40px;
  font-size: 18px;
}

nav a {
  text-decoration: none;
  color: #2563eb;
  font-weight: 600;
  padding: 6px 12px;
  border-radius: 6px;
  transition: background-color 0.3s, color 0.3s;
}

nav a:hover {
  background-color: #bfdbfe;
  color: #1e3a8a;
}

.active-link {
  background-color: #3b82f6;
  color: white;
}
</style>
