<template>
  <div v-if="users != null && users.length == 0">
    <input
      type="text"
      placeholder="Search office by address"
      v-model="searchPattern"
    />
    <button @click="onOfficeSearch">Search</button>
    <button @click="onUserSearch">Get Users</button>
    <div class="user-list">
      <div v-for="office in offices" v-bind:key="office.id">
        <div>
          <input
            type="checkbox"
            :checked="selectedOffices.indexOf(office.id) >= 0"
            @click="onSelectOffice(office.id)"
          />
          Address: <span class="bold"> {{ office.address }} </span>
        </div>
      </div>
    </div>
  </div>
  <div v-if="users.length > 0">
    <UserList :users="users" :officeIds="offices.value" />
  </div>
</template>

<script lang="ts">
import { ref } from "vue";
import UserList from "./components/UserList.vue";
import officeService from "./services/OfficeService";
import userService from "./services/UserService";
import Office from './models/Office';
import { User } from './models/user';

export default {
  components: { UserList },
  setup() {
    let searchPattern = ref("");
    let offices = ref([] as Office[]);
    let users = ref([] as User[]);

    let selectedOffices = ref([] as string[]);
    

    function onOfficeSearch() {
      officeService
        .getOffices(searchPattern.value)
        ?.then((o) => (offices.value = o));
    }

    function onUserSearch() {

      userService
        .getUsers(selectedOffices.value)
        ?.then((o) => users.value = o );


    }

    function onSelectOffice(id: string) {
      if (selectedOffices.value.indexOf(id) >= 0) {
        selectedOffices.value = selectedOffices.value.filter((o) => o != id);
      } else {
        selectedOffices.value.push(id);
      }
    }

    return {
      searchPattern,
      offices,
      users,
      selectedOffices,
      onOfficeSearch,
      onUserSearch,
      onSelectOffice,
    };
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.bold {
  font-weight: bold;
}
.user-list {
  text-align: left;
}
</style>
