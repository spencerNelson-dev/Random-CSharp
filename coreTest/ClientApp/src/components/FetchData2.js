import React from 'react';

function FetchData2(props) {

    const [state, setState] = React.useState({projects: [], loading: true})

    React.useEffect(() => {
        populateWeatherData();
    }, [])

    const populateWeatherData = async () => {
        const response = await fetch('projects');
        const data = await response.json();
        setState({ projects: data, loading: false });
    }

    const renderProjectsTable = (projects=[]) => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Title</th>
                  <th>Text</th>
                  <th>Live Link</th>
                  <th>GitHub Links</th>
                  <th>Picture</th>
                </tr>
              </thead>
              <tbody>
                {projects.map(project =>
                  <tr key={project.title}>
                    <td>{project.title}</td>
                    <td>{project.text}</td>
                    <td>{project.liveLink}</td>
                    <td>{project.gitHubLinks}</td>
                    <td>{project.imgSrc}</td>
                  </tr>
                )}
              </tbody>
            </table>
          );
    }

    let contents = state.loading ? (<p><em>Loading...</em></p>) : (renderProjectsTable(state.projects))

    return (
        <div>
            {console.log(state)}
            <h1>Table of projects</h1>
            {contents}
        </div>
    );
}

export default FetchData2;