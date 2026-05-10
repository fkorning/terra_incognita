package net.terria.registry.terraform;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

import static org.assertj.core.api.Assertions.assertThat;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.DynamicPropertyRegistry;
import org.springframework.test.context.DynamicPropertySource;

@SpringBootTest
public class RegistryServiceTest {

    private static final Path REGISTRY_STORAGE_PATH = Path.of("registry/");

    @Autowired
    private RegistryService registryService;

    @DynamicPropertySource
    static void dynamicProperties(DynamicPropertyRegistry registry) {
        registry.add("registry.storage.path", () -> REGISTRY_STORAGE_PATH.toString());
    }

    @BeforeEach
    public void initStorage() throws IOException {

        Path registryPath = REGISTRY_STORAGE_PATH.resolve("registry.terraform.io");
        Path providersPath = registryPath.resolve("providers");
        Path modulesPath = registryPath.resolve("modules");

        Files.createDirectories(providersPath);
        Files.createDirectories(modulesPath);

        // Re-init service after cleanup
        registryService.init();

    }

    @Test
    public void testInitWithProvider() throws IOException {
        // Create provider structure under registry.terraform.io/providers/
        Path registryPath = REGISTRY_STORAGE_PATH.resolve("registry.terraform.io");
        Path providersPath = registryPath.resolve("providers");
        Path namespacePath = providersPath.resolve("hashicorp");
        Path providerPath = namespacePath.resolve("aws");
        Path versionPath = providerPath.resolve("1.0.0");
        Path platformPath = versionPath.resolve("linux").resolve("amd64");

        Files.createDirectories(platformPath);
        //Files.createFile(providersPath.resolve("namespaces.json"));

        // Re-init service after test data creation
        registryService.init();

        assertThat(registryService.getProviders()).hasSize(1);
        assertThat(registryService.getProvider("registry.terraform.io", "hashicorp", "aws")).isPresent();
    }


    // Add more tests as needed
}