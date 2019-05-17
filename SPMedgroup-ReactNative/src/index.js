import {
    createBottomTabNavigator,
    createAppContainer,
    createStackNavigator,
    createSwitchNavigator
} from "react-navigation";

import Login from './pages/Login.js';
import Lista from './pages/Lista.js';

const AuthStack = createStackNavigator({ Login });

const lista = createStackNavigator({Lista});

export default createAppContainer(
    createSwitchNavigator(
        {
            lista,
            AuthStack
        },
        {
            initialRouteName: "AuthStack"
        }
    )
);


