import React, { Component } from 'react';
import { StyleSheet, View, Text } from 'react-native';
import { Container, Content, Card, CardItem, Separator, Row, Title } from 'native-base';
import { AccordionList } from "accordion-collapse-react-native";
import api from '../services/API.js';
import AsyncStorage from '@react-native-community/async-storage';




export default class App extends Component {
  static navigationOptions = {
    header: null
  };


  constructor(props) {
    super(props)
    this.state = {
      // token: '',
      list: [
        {
          medico: 'davizin',
          title: 'Getting Started',
          body: 'React native Accordion/Collapse component, very good to use in toggles & show/hide content'
        },
        {
          medico: 'davizin',
          title: 'Components',
          body: 'AccordionList,Collapse,CollapseHeader & CollapseBody'
        }
      ],
    }

  }

  componentWillMount() {
    this._buscarLista();

  }


  _buscarToken = async () => {

    const token = await AsyncStorage.getItem("userToken");


    this.setState({ token: token })
  }

  _buscarLista = async () => {
    await this._buscarToken();

    await api.get('/Consultas', {
      headers: {
        'Authorization': 'Bearer ' + (this.state.token)
      }
    })
      .then(resposta => {        
        this.setState({ list: resposta.data });
      })
      .catch(error => {
        console.warn(error);
      })

  }






  _head(item) {
    return (
      <Separator bordered style={{ alignItems: 'center', borderRadius: 5 }}>
        <Text>{item.data}</Text>
      </Separator>
    );
  }

  _body(item) {
    return (
      <View>
        <View style={style.color}>
          <Text>Paciente: {item.paciente}</Text>
          <Text>Médico: {item.medico}</Text>
          <Text>Status: {item.status}</Text>
          <Text>Descrição: {item.descricao}</Text>

        </View>
      </View>
    );
  }
  render() {
    return (
      <View style={style.main}>
        <Title style={style.titulo}>Minhas Consultas</Title>
        <View style={style.list}>
          <AccordionList

            list={this.state.list}

            header={this._head}
            body={this._body}
          />
        </View>
      </View>
    );
  }
}

const style = StyleSheet.create({

  main: {
    flex: 1,
    width: "100%",
    height: "100%",
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center",
    marginTop: -50,
    paddingTop: 70,
    backgroundColor: "rgba(19, 10, 143, 0.90)"
  },
  list: {
    marginTop: 20,
    width: "80%",
    height: "100%",
  },

  color: {
    backgroundColor: "#17cf91",
    padding: 10,
    width: "100%",
    borderRadius: 5
  },
  body: {
    width: "100%",
  },
  titulo: {
    marginTop: 20,
  }

})