<template>
    <div>
        <b-table striped hover :items="Users"></b-table>
        <section>
            <button class="first-page-btn" v-on:click="firstPage()">
                first
            </button>
            <button class="previous-page-btn" v-on:click="previousPage()">
                previous
            </button>
            <button class="next-page-btn" v-on:click="nextPage()">
                next
            </button>
            <button class="last-page-btn" v-on:click="lastPage()">
                last
            </button>
        </section>
    </div>
</template>
<script>
import axios from "axios";

export default {
  data() {
    return {
      allUsers: [],
      Users: [],
      page: 0,
      totalPage: 0,
      pageSize: 10
    };
  },
  created() {
    this.all();
  },
  methods: {
    lastPage : function()
    {
      this.page = this.totalPage;
      this.paginate(this.page);
    },
    firstPage : function() {
        this.page = 0;
        this.paginate(this.page);
    },
    nextPage : function() {
        this.page += 1;
        if (this.page > this.totalPage) {
            this.page = this.totalPage;
        }
        this.paginate(this.page);
    },
    previousPage : function() {
        this.page -= 1;
        if (this.page < 0) {
            this.page = 0;
        }
        this.paginate(this.page);
    },
    paginate : function(page) {
        let i = 0;
        this.Users.splice(0, this.Users.length);
        while(i < this.allUsers.length) {
            if ( i >= page * this.pageSize && i < (this.page + 1)* this.pageSize)
            {
                this.Users.push(this.allUsers[i]);
                console.log(this.Users);
            }
            i++;
        }
    },
    all: function() {
      axios.get("https://localhost:44390/User").then((response) => {
        console.log(response.data.value);
        this.allUsers = response.data.value;
        this.totalPage = Math.round(this.allUsers.length / this.pageSize);

        this.paginate(0);
      });
    },
  },
};
</script>