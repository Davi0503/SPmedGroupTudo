import React, { Component } from 'react';
import { StyleSheet, TextInput, Text, View, Button, ImageBackground, Image, StatusBar } from 'react-native';
import api from '../services/API.js'

class Login extends Component {
    static navigationOptions = {
        header: null
    };


    constructor(props) {
        super(props);
        this.state = { Email: "", Senha: "" };
    }

    _realizaLogin() {
        console.warn("lista");
    }

    render() {
        return (            
            
            <ImageBackground
                source={require("../assets/img/background.jpg")}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={style.overlay} />
                <StatusBar
                backgroundColor="rgb(19, 10, 143)"></StatusBar>
                <View style={style.main}>
                
                    <Image
                        source={require("../assets/img/icon-login.png")}
                        style={style.logo}
                    ></Image>
                    <View style={style.inputs}>
                        <TextInput
                            placeholder="Email"
                            underlineColorAndroid="#17cf91"
                            style={style.inputLogin}
                            placeholderTextColor="#baf7e3"
                            TextColor="#17cf91"
                            
                        />

                        <TextInput
                            style={style.inputLogin}
                            placeholder="Senha"
                            underlineColorAndroid="#17cf91"
                            placeholderTextColor="#baf7e3"
                            secureTextEntry={true}
                        />
                      
                        <Button
                            title="Login"
                            color="#17cf91"
                            onPress={() => this.props.navigation.navigate("lista")}
                        />
                        
                    </View>

                </View>
            </ImageBackground>
        );
    }
}



const style = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: "rgba(19, 10, 143, 0.59)"
    },
    main: {
        width: "100%",
        height: "100%",
        justifyContent: "center",
        alignContent: "center",
        alignItems: "center",
        marginTop: -50

    },
    inputLogin: {
        marginTop: 10,
        width: "100%",
        marginBottom: 20,
        fontSize: 15,
        color: "#17cf91"

    },

    logo: {
        width: 150,
        height: 160
    },
    inputs: {
        marginTop: 60,
        width: "80%",
        justifyContent: "center",
        alignContent: "center",
        alignItems: "center",
    },
});

export default Login;