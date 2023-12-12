import BookSearch from "./Components/BookSearch";
import Home from "./Components/Home";
import BookClubs from "./Components/BookClubs";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/booksearch",
    element: <BookSearch />,
  },
  {
    path: "/bookclubs",
    element: <BookClubs />,
  },
];

export default AppRoutes;
