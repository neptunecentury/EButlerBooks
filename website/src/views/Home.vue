<template>
  <v-container>
    <v-card color="blue-lighten-2" elevation="12">

      <v-card-text>
        <v-row>
          <v-col :cols="3">
            <v-img class="bg-white" :aspect-ratio="1" src="https://cdn.vuetifyjs.com/images/parallax/material.jpg"
              cover></v-img>
          </v-col>
          <v-col cols="auto">
            I've been writing since 2005. Yada Yada.
          </v-col>
        </v-row>


      </v-card-text>

    </v-card>

    <div v-for="book in books">
      {{ book.title }}
      <br />
      Written by
      <br />
      <div v-for="author in book.authors">
      {{ author.fullName }}
      </div>
      Genres:
      <div v-for="genre in book.genres">
      {{ genre.name }}
      </div>
    </div>


  </v-container>
</template>

<script lang="ts" setup>
import axios from 'axios'
import { ref } from 'vue'
import { Book } from '@/interfaces/models'

const books = ref<Book[]>();

/**
 * Gets books from the API
 */
async function getBooks(): Promise<void> {

  try {
    const booksResponse = await axios.get<Book[]>(`https://localhost:7204/books`)
    // Set the books
    if (booksResponse) {
      books.value = booksResponse.data//.map(b => {return <Book> { title: b.title }});

        console.log(books.value)
    }
  }
  catch (ex) {

  }

}

// Get books from API
getBooks();

</script>
