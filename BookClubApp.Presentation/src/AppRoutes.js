import  Counter  from "./Components/Counter";
import  FetchData  from "./Components/FetchData";
import  Home  from "./Components/Home";
import  BookClubs  from "./Components/BookClubs";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  }
  ,
  {
    path: '/bookclubs',
    element: <BookClubs />
  }
];

export default AppRoutes;
