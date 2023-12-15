import BookSearch from "./Components/BookSearch";
import Home from "./Components/Home";
import BookClubs from "./Components/BookClubs";
import FavBooks from "./Components/FavBooks";

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
    path: "/favbooks",
    element: <FavBooks />,
  },
  {
    path: "/bookclubs",
    element: <BookClubs />,
  },
];

export default AppRoutes;
